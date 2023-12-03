﻿using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using MemorySearchV2.ExtraForms;
using MemorySearchV2.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XDevkit;

namespace MemorySearchV2
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Global
        public static IXboxConsole xb;
        public static bool activeConnection;
        public static ListViewItem extlvi = null;
        #endregion

        #region Splashcreen handler
        private void CloseSplash()
        {
            if (splashScreenManager1.IsSplashFormVisible)
                splashScreenManager1.CloseWaitForm();
        }
        #endregion

        #region Connection
        private bool Connect()
        {
            try
            {
                IXboxConsole newConnection = xb;
                if (newConnection.Connect(out newConnection))
                {
                    activeConnection = true;
                    SearchButton.Enabled = true;
                    xb = newConnection;  
                }
                else
                {
                    SearchButton.Enabled = false;
                    activeConnection = false;
                }
                return activeConnection;
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
                SearchButton.Enabled = false;
                activeConnection = false;
                return false;
            }
        }
        #endregion

        private void LoadProgramSettings()
        {
            ResultsToDisplayInput.Value = (decimal)Properties.Settings.Default.ResultsToDisplay;
            addrBox.Text = Properties.Settings.Default.PreviousStartAddress;
            sizeBox.Text = Properties.Settings.Default.PreviousEndAddress;
            valBox.Text = Properties.Settings.Default.PreviousValue;
            dataType_.Text = Properties.Settings.Default.PreviousDataType;
            isHex.Checked = Properties.Settings.Default.IsHexValue;
            LittleEndianBox.Checked = Properties.Settings.Default.IsLittleEndianValue;
            pause.Checked = Properties.Settings.Default.PauseWhileSearching;
            RefreshIntervalEdit.Value = (decimal)Properties.Settings.Default.RefreshTableValuesInterval;
            AutoConnect.Checked = Properties.Settings.Default.AutoConnect;

            if (Properties.Settings.Default.AutoConnect)
            {
                if (!Connect())
                    ErrorHelper.ConnectionError();
            }
        }

        private void SaveProgramSettings()
        {
            Properties.Settings.Default.ResultsToDisplay = (int)ResultsToDisplayInput.Value;
            Properties.Settings.Default.PreviousStartAddress = addrBox.Text;
            Properties.Settings.Default.PreviousEndAddress = sizeBox.Text;
            Properties.Settings.Default.PreviousValue = valBox.Text;
            Properties.Settings.Default.PreviousDataType = dataType_.Text;
            Properties.Settings.Default.IsHexValue = isHex.Checked;
            Properties.Settings.Default.IsLittleEndianValue = LittleEndianBox.Checked;
            Properties.Settings.Default.PauseWhileSearching = pause.Checked;
            Properties.Settings.Default.RefreshTableValuesInterval = (int)RefreshIntervalEdit.Value;
            Properties.Settings.Default.AutoConnect = AutoConnect.Checked;
            Properties.Settings.Default.Save();
        }

        public MainForm()
        {
            InitializeComponent();
            SearchButton.Enabled = false;
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Black", "Fire Brick");
            DevExpress.XtraEditors.WindowsFormsSettings.UseDXDialogs = DevExpress.Utils.DefaultBoolean.True;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProgramSettings();
        }

        private void ConnectButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Connect())
                ErrorHelper.ConnectionError();
            else SearchButton.Enabled = true;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SearchHelper.ValidateUserInputs(addrBox.Text, sizeBox.Text, valBox.Text, dataType_.Text, isHex.Checked))
                    return;

                timer1.Stop();
                int searchSize;
                byte[] searchValue = SearchHelper.GetSearchParameters(dataType_.Text, valBox.Text, isHex.Checked, LittleEndianBox.Checked, out searchSize);

                SearchHelper.searchResults.Clear();
                resultList.Items.Clear();
                resultList.Items.AddRange(SearchHelper.PerformMemorySearchParallel(addrBox.Text, sizeBox.Text, valBox.Text, searchSize, searchValue, pause.Checked, splashScreenManager1).Take((int)ResultsToDisplayInput.Value).ToArray());
                CloseSplash();
                timer1.Start();
            }
            catch(Exception ex)
            {
                CloseSplash();
                ErrorHelper.Error(ex);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (pause.Checked)
                    xb.DebugTarget.Stop(out bool isStopped);

                timer1.Stop();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                splashScreenManager1.ShowWaitForm();

                ListView.ListViewItemCollection list = resultList.Items;
                List<ListViewItem> itemsToAdd = new List<ListViewItem>();

                int searchSize;
                byte[] searchValue = SearchHelper.GetSearchParameters(dataType_.Text, valBox.Text, isHex.Checked, LittleEndianBox.Checked, out searchSize);

                int found = 0;

                foreach (ListViewItem resultItem in SearchHelper.searchResults)
                {
                    uint address = uint.Parse(resultItem.Text.Replace("0x", ""), NumberStyles.HexNumber);

                    byte[] buffer = xb.GetMemory2(address, (uint)searchSize);

                    if (buffer.SequenceEqual(searchValue))
                    {
                        ListViewItem lvi = new ListViewItem("0x" + address.ToString("X8"));
                        lvi.SubItems.Add((string)valBox.Text.Clone());
                        lvi.SubItems.Add(resultItem.SubItems[2].Text);
                        itemsToAdd.Add(lvi);
                        found++;
                    }
                    else
                    {
                        // Remove invalid result from the list
                        list.Remove(resultItem);
                    }
                }

                for (int i = SearchHelper.searchResults.Count - 1; i >= 0; i--)
                {
                    string subItemValue = SearchHelper.searchResults[i].SubItems[1].Text;

                    if (!subItemValue.Contains(valBox.Text))
                    {
                        SearchHelper.searchResults.RemoveAt(i);
                    }
                }

                resultList.Items.Clear();
                resultList.Items.AddRange(itemsToAdd.Take((int)ResultsToDisplayInput.Value).ToArray());

                if (found == 0)
                {
                    resultList.Items.Clear(); // Clear the list if no valid results are found
                    AcceptButton = SearchButton;
                }

                if (pause.Checked)
                    xb.DebugTarget.Go(out bool isStopped);

                CloseSplash();
                stopwatch.Stop();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                int hours = (int)(elapsedMilliseconds / (1000 * 60 * 60));
                int minutes = (int)((elapsedMilliseconds % (1000 * 60 * 60)) / (1000 * 60));
                int seconds = (int)((elapsedMilliseconds % (1000 * 60)) / 1000);
                int milliseconds = (int)(elapsedMilliseconds % 1000);

                string elapsedTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}:{milliseconds:D3}";

                ErrorHelper.MessageDialogBox($"Successfully found: {found} matches\n\nSearch Time: {elapsedTime}", "Search Results");
                timer1.Start();
            }
            catch (Exception ex)
            {
                CloseSplash();
                ErrorHelper.Error(ex);
            }
        }

        private void AddToTableButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (resultList.SelectedItems.Count != 1) return;
            else if (dataType_.Text == "String") new AddEntryForm(resultList.SelectedItems[0].Text, "String (" + valBox.SelectionLength + ")").ShowDialog();
            else
                new AddEntryForm(resultList.SelectedItems[0].Text, "", resultList.SelectedItems[0].SubItems[1].Text, dataType_.Text).ShowDialog();
            if (extlvi != null)
            {
                tableList.Items.Add(extlvi);
                extlvi = null;
            }
        }

        private void ChangeValueButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (resultList.SelectedItems.Count != 1) return;
                new ChangeValueForm(resultList.SelectedItems[0].Text, dataType_.Text, resultList.SelectedItems[0].SubItems[1].Text).ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        private void RemoveEntryButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (resultList.SelectedItems.Count != 1) return;
            if (XtraMessageBox.Show("Are you sure you want to remove this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                resultList.SelectedItems[0].Remove();
        }

        private void ClearResultsListButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (resultList.Items.Count != 0)
            {
                if( XtraMessageBox.Show("Are you sure you want to clear the current results list?", "Clear Results", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultList.Items.Clear();
                }
            }
        }

        private void SaveShortListToJsonButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
              JsonHelper.SaveSearchResultsShortList(resultList);
        }

        private void SaveLongResultsListButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JsonHelper.SaveSearchResultsLongList();
        }

        private void SaveCheatTableButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JsonHelper.SaveCheatTable(tableList);
        }

        private void LoadCheatTableMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JsonHelper.LoadCheatTable(tableList, false);
        }

        private void ChangeValueTableMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (tableList.SelectedItems.Count != 1) return;
                new ChangeValueForm(tableList.SelectedItems[0].Text, tableList.SelectedItems[0].SubItems[2].Text, tableList.SelectedItems[0].SubItems[3].Text).ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        private void EditEntryTableMenuitem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tableList.SelectedItems.Count != 1) return;
            new AddEntryForm(tableList.SelectedItems[0].Text, tableList.SelectedItems[0].SubItems[1].Text, tableList.SelectedItems[0].SubItems[2].Text).ShowDialog();
            if (extlvi != null)
            {
                tableList.SelectedItems[0].Text = extlvi.Text;
                tableList.SelectedItems[0].SubItems[1] = extlvi.SubItems[1];
                tableList.SelectedItems[0].SubItems[2] = extlvi.SubItems[2];
                extlvi = null;
            }
        }

        private void RemoveTableEntryMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tableList.SelectedItems.Count != 1) return;
            if (XtraMessageBox.Show("Are you sure you want to remove this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                tableList.SelectedItems[0].Remove();
        }

        private void ClearCheatTableMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (resultList.Items.Count != 0)
            {
                if (XtraMessageBox.Show("Are you sure you want to clear the current cheat table?", "Clear Results", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tableList.Items.Clear();
                }
            }
        }

        private void ManuallyAddEntryMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new AddEntryForm().ShowDialog();
            if (extlvi != null)
            {
                tableList.Items.Add(extlvi);
                extlvi = null;
            }
        }

        private void SaveTableButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JsonHelper.SaveCheatTable(tableList);
        }

        private void LoadTableButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (activeConnection)
                 JsonHelper.LoadCheatTable(tableList, RefreshValuesBox.Checked);
            else
            {
                timer1.Stop();
                JsonHelper.LoadCheatTable(tableList, false);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveProgramSettings();
                if (resultList.Items.Count <= 0 && tableList.Items.Count <= 0)
                {
                    // No items, allow closing without prompt
                    e.Cancel = false;
                }
                else
                {
                    DialogResult result = XtraMessageBox.Show("Would You Like To Save Before Closing?", "Save Cheat Table", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        XtraSaveFileDialog sfd = new XtraSaveFileDialog
                        {
                            Title = "Save Xbox 360 Cheat Table",
                            Filter = "Xbox 360 Cheat Table (.xct)|*.xct"
                        };

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();

                            foreach (ListViewItem lvi in tableList.Items)
                            {
                                Dictionary<string, string> itemDict = new Dictionary<string, string>
                                 {
                                      { "Address", lvi.Text },
                                      { "Description", lvi.SubItems[1].Text },
                                      { "Type", lvi.SubItems[2].Text },
                                      { "Value", lvi.SubItems[3].Text }
                                 };
                                 dataList.Add(itemDict);
                            }

                            string jsonContent = JsonConvert.SerializeObject(dataList, Formatting.Indented);
                            File.WriteAllText(sfd.FileName, jsonContent); 
                        }
                        else
                        {
                            // User canceled the save dialog, cancel the form closing
                            e.Cancel = true;
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        // User chose not to save, allow closing without saving
                        e.Cancel = false;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // User canceled the prompt, cancel the form closing
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }


        private void AutoConnect_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Properties.Settings.Default.AutoConnect = AutoConnect.Checked;
        }

        public void SetupRefreshTimer()
        {
            try
            {
                if (activeConnection && RefreshValuesBox.Checked)
                {
                    timer1.Interval = (int)RefreshIntervalEdit.Value * 1000;
                    JsonHelper.RefreshCheatTableValues(tableList);
                }
            }
            catch(Exception ex)
            {
                timer1.Stop();
                ErrorHelper.Error(ex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SetupRefreshTimer();
            }
            catch(Exception ex)
            {
                timer1.Stop();
                ErrorHelper.Error(ex);
            }
        }

        private void RefreshValuesBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RefreshValuesBox.Checked) timer1.Start();
            else timer1.Stop();
        }

        private void resultList_DoubleClick(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count != 1) return;
            else if (dataType_.Text == "String") new AddEntryForm(resultList.SelectedItems[0].Text, "String (" + valBox.SelectionLength + ")").ShowDialog();
            else
                new AddEntryForm(resultList.SelectedItems[0].Text, "", resultList.SelectedItems[0].SubItems[1].Text, dataType_.Text).ShowDialog();
            if (extlvi != null)
            {
                tableList.Items.Add(extlvi);
                extlvi = null;
            }
        }
    }
}
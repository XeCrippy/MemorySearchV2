﻿using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using MemorySearchV2.ExtraForms;
using MemorySearchV2.Helpers;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using XDevkit;

/// <summary>
/// Inspired by Xbox 360 Cheat Engine by XeClutch
/// </summary>
namespace MemorySearchV2
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Global
        public static IXboxConsole xb;
        public static ListViewItem extlvi = null;
        public static bool activeConnection;
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

        private void GetConnectionState()
        {
            if (activeConnection)
            {
                ConnectCheck.Checked = true;
            }
            else
            {
                ConnectCheck.Checked = false;
            }
        }
        #endregion

        #region Program Settings
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
            IsDevKitCheck.Checked = Properties.Settings.Default.IsDevKit;

            if (Properties.Settings.Default.AutoConnect)
            {
                if (!Connect())
                    ErrorHelper.ConnectionError();
                else ConnectCheck.Checked = true;
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
            Properties.Settings.Default.IsDevKit = IsDevKitCheck.Checked;
            Properties.Settings.Default.Save();
        }
        #endregion

        public MainForm()
        {
            InitializeComponent();
            SearchButton.Enabled = false;
            NextButton.Enabled = false;
            SearchChangedValuesButton.Enabled = false;
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Black", "Fire Brick");
            WindowsFormsSettings.UseDXDialogs = DevExpress.Utils.DefaultBoolean.True;
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

        private void ConnectCheck_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConnectCheck.Checked && Connect())
            {
                SearchButton.Enabled = true;
            }
            else if (ConnectCheck.Checked && !Connect())
            {
                ErrorHelper.ConnectionError();
            }
            else
            {
                SearchButton.Enabled = false;
                activeConnection = false;
            }
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

                uint chunk; 
                if (uint.TryParse(ChunkSizeEdit.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out chunk))
                    resultList.Items.AddRange(SearchHelper.PerformInitialSeach(addrBox.Text, sizeBox.Text, valBox.Text, searchSize, searchValue, pause.Checked, splashScreenManager1, chunk).Take((int)ResultsToDisplayInput.Value).ToArray());
                else 
                    ErrorHelper.MessageDialogBox("Value for Chunk Size must be in Hexidecimal", "Chunk Size Input Error");

                CloseSplash();

                NextButton.Enabled = (resultList.Items.Count != 0);
                SearchChangedValuesButton.Enabled = (resultList.Items.Count != 0);
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
                timer1.Stop(); // stop timer tick while searching
                SearchHelper.PerformFollowUpSearches(pause.Checked, resultList, dataType_.Text, valBox.Text, isHex.Checked, LittleEndianBox.Checked, (int)ResultsToDisplayInput.Value, splashScreenManager1);

                if (resultList.Items.Count == 0)
                    AcceptButton = SearchButton;

                NextButton.Enabled = resultList.Items.Count != 0;
                SearchChangedValuesButton.Enabled = resultList.Items.Count != 0;

                timer1.Start(); // start again once finished
            }
            catch(Exception ex)
            {
                CloseSplash();
                ErrorHelper.Error(ex);
            }
        }

        private void AddToTableButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (resultList.SelectedItems.Count == 0) return;
                else if (resultList.SelectedItems.Count > 1)
                {
                    for (int i = 0; i < resultList.SelectedItems.Count; i++)
                    {
                        tableList.Items.Add(resultList.SelectedItems[i].Text);
                        tableList.Items[i].SubItems.Add("");
                        tableList.Items[i].SubItems.Add("");
                        tableList.Items[i].SubItems.Add(resultList.SelectedItems[i].SubItems[1].Text);
                    }
                }
                else if (dataType_.Text == "STRING") new AddEntryForm(resultList.SelectedItems[0].Text, "", valBox.Text, dataType_.Text).ShowDialog();
                else
                    new AddEntryForm(resultList.SelectedItems[0].Text, "", resultList.SelectedItems[0].SubItems[1].Text, dataType_.Text).ShowDialog();
                if (extlvi != null)
                {
                    tableList.Items.Add(extlvi);
                    extlvi = null;
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
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
            if (activeConnection)
                JsonHelper.LoadCheatTable(tableList, true);
            else
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
            new AddEntryForm(tableList.SelectedItems[0].Text, tableList.SelectedItems[0].SubItems[1].Text, tableList.SelectedItems[0].SubItems[3].Text, tableList.SelectedItems[0].SubItems[2].Text).ShowDialog();
            if (extlvi != null)
            {
                tableList.SelectedItems[0].Text = extlvi.Text;
                tableList.SelectedItems[0].SubItems[1] = extlvi.SubItems[1];
                tableList.SelectedItems[0].SubItems[2] = extlvi.SubItems[2];
                tableList.SelectedItems[0].SubItems[3] = extlvi.SubItems[3];
                extlvi = null;
            }
        }

        private void RemoveTableEntryMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tableList.SelectedItems.Count == 0) return;
            if (XtraMessageBox.Show("Are you sure you want to remove this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                for (int i = 0; i < tableList.SelectedItems.Count; i++)
                {
                    tableList.SelectedItems[i].Remove();
                }
        }

        private void ClearCheatTableMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tableList.Items.Count != 0)
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
                 JsonHelper.LoadCheatTable(tableList, true);
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
                JsonHelper.SaveCheatTable(tableList, e);
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

        private void SetupRefreshTimer()
        {
            try
            {
                if (activeConnection && RefreshValuesBox.Checked)
                {
                    timer1.Interval = (int)RefreshIntervalEdit.Value * 1000;
                    ListViewHelper.RefreshCheatTableValues(tableList);
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
                GetConnectionState();
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
            try
            {
                if (resultList.SelectedItems.Count == 0) return;
                else if (dataType_.Text == "STRING") new AddEntryForm(resultList.SelectedItems[0].Text, "", valBox.Text, dataType_.Text).ShowDialog();
                else
                    new AddEntryForm(resultList.SelectedItems[0].Text, "", resultList.SelectedItems[0].SubItems[1].Text, dataType_.Text).ShowDialog();
                if (extlvi != null)
                {
                    tableList.Items.Add(extlvi);
                    extlvi = null;
                }
            }
            catch(Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        private void SearchChangedValuesButton_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop(); // stop timer tick while searching
                SearchHelper.PerformFollowUpSearchesForChangedValues(pause.Checked, resultList, dataType_.Text, isHex.Checked, LittleEndianBox.Checked, (int)ResultsToDisplayInput.Value, splashScreenManager1);

                if (resultList.Items.Count == 0)
                    AcceptButton = SearchButton;

                NextButton.Enabled = resultList.Items.Count != 0;
                SearchChangedValuesButton.Enabled = resultList.Items.Count != 0;

                timer1.Start(); // start again once finished
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        private void tableList_DoubleClick(object sender, EventArgs e)
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

        private void ConsoleInfoMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (activeConnection)
            {
                ConsoleInfo consoleInfo = new ConsoleInfo();
                consoleInfo.Show();
            }
            else ErrorHelper.ConnectionError();
        }

        private void IsDevKitCheck_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Properties.Settings.Default.IsDevKit = IsDevKitCheck.Checked;
        }

        private void CheatTableConverter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CheatTableConversion tableConverter = new CheatTableConversion();
                tableConverter.ConvertTableToCsClass();
            }
            catch(Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        private void RebootConsoleMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Are you sure you want to reboot?", "Reboot Console", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (activeConnection)
                    xb.Reboot(null, null, null, XboxRebootFlags.Cold);
                else ErrorHelper.ConnectionError();
            }
        }

        private void ShutdownConsoleMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Are you sure you want to shut console down?", "Shutdown Console", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (activeConnection)
                    xb.ShutDownConsole();
                else ErrorHelper.ConnectionError();
            }
        }
    }
}

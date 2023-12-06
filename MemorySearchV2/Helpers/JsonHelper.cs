using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MemorySearchV2.Helpers
{
    public static class JsonHelper
    {
        public static void LoadCheatTable(ListView cheatTableListView, bool refresh)
        {
            XtraOpenFileDialog ofd = new XtraOpenFileDialog
            {
                Title = "Load Xbox 360 Cheat Table",
                Filter = "Xbox 360 Cheat Table (.xct)|*.xct"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadJsonData(ofd.FileName, cheatTableListView, refresh);
            }
        }

        public static void LoadJsonData(string filePath, ListView listView, bool refresh)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);

                List<ListViewHelper.CheatEntry> cheatEntries = JsonConvert.DeserializeObject<List<ListViewHelper.CheatEntry>>(jsonData);

                listView.Items.Clear();

                foreach (ListViewHelper.CheatEntry entry in cheatEntries)
                {
                    if (ShouldSkipEntry(entry))
                        continue;
                    if (cheatEntries is null)
                        break;

                    ListViewItem lvi = ListViewHelper.CreateTableListViewItem(entry, refresh);
                    listView.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        public static void SaveCheatTable(ListView cheatTableListView)
        {
            try
            {
                if (cheatTableListView.Items.Count == 0)
                {
                    ErrorHelper.Error("You currently don't have any entries to save", "Null Entries Error");
                    return;
                }

                XtraSaveFileDialog sfd = new XtraSaveFileDialog
                {
                    Title = "Save Xbox 360 Cheat Table",
                    Filter = "Xbox 360 Cheat Table (.xct)|*.xct"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();

                    foreach (ListViewItem lvi in cheatTableListView.Items)
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
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        public static void SaveCheatTable(ListView listView, FormClosingEventArgs e)
        {
            try
            {
                if (listView.Items.Count <= 0 && listView.Items.Count <= 0)
                {
                    // No items, allow closing without prompt
                    e.Cancel = false;
                }
                else
                {
                    DialogResult result = XtraMessageBox.Show("Would You Like To Save Before Closing?", "Save Cheat Table", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        JsonHelper.SaveCheatTable(listView);
                        XtraSaveFileDialog sfd = new XtraSaveFileDialog
                        {
                            Title = "Save Xbox 360 Cheat Table",
                            Filter = "Xbox 360 Cheat Table (.xct)|*.xct"
                        };

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();

                            foreach (ListViewItem lvi in listView.Items)
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

        public static void SaveSearchResultsShortList(ListView resultsView)
        {
            try
            {
                if (resultsView.Items.Count == 0)
                {
                    ErrorHelper.MessageDialogBox("You currently don't have any results to save", "Null Entries Error");
                    return;
                }

                XtraSaveFileDialog sfd = new XtraSaveFileDialog
                {
                    Title = "Save Save Search Results Displayed List",
                    Filter = "Json File (.json)|*.json"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();

                    foreach (ListViewItem lvi in resultsView.Items)
                    {
                        Dictionary<string, string> itemDict = new Dictionary<string, string>
                        {
                           { "Address", lvi.Text },
                           { "Value", lvi.SubItems[1].Text },
                           { "Previous", lvi.SubItems[2].Text },
                         };

                        dataList.Add(itemDict);
                    }

                    string jsonContent = JsonConvert.SerializeObject(dataList, Formatting.Indented);
                    File.WriteAllText(sfd.FileName, jsonContent);
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        public static void SaveSearchResultsLongList()
        {
            try
            {
                if (SearchHelper.searchResults.Count == 0)
                {
                    ErrorHelper.MessageDialogBox("You currently don't have any results to save", "Null Entries Error");
                    return;
                }

                XtraSaveFileDialog sfd = new XtraSaveFileDialog
                {
                    Title = "Save Search Results Full List",
                    Filter = "Json File (.json)|*.json"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();

                    foreach (ListViewItem lvi in SearchHelper.searchResults)
                    {
                        Dictionary<string, string> itemDict = new Dictionary<string, string>
                        {
                           { "Address", lvi.Text },
                           { "Value", lvi.SubItems[1].Text },
                           { "Previous", lvi.SubItems[2].Text },
                         };

                        dataList.Add(itemDict);
                    }

                    string jsonContent = JsonConvert.SerializeObject(dataList, Formatting.Indented);
                    File.WriteAllText(sfd.FileName, jsonContent);
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        public static bool ShouldSkipEntry(ListViewHelper.CheatEntry entry)
        {
            return string.IsNullOrEmpty(entry.Address) &&
                   string.IsNullOrEmpty(entry.Description) &&
                   string.IsNullOrEmpty(entry.Type) &&
                   string.IsNullOrEmpty(entry.Value);
        }
    }
}

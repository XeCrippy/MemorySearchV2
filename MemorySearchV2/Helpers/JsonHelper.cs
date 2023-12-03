using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace MemorySearchV2.Helpers
{
    public static class JsonHelper
    {
        public class CheatEntry
        {
            public string Address { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
        }

        private static CheatEntry GetCheatEntryFromListViewItem(ListViewItem item)
        {
            return new CheatEntry
            {
                Address = item.Text,
                Description = item.SubItems[1].Text,
                Type = item.SubItems[2].Text,
                Value = item.SubItems[3].Text
            };
        }

        private static ListViewItem CreateListViewItem(CheatEntry entry, bool refresh)
        {
            ListViewItem lvi = new ListViewItem(entry.Address);
            lvi.SubItems.Add(entry.Description);
            lvi.SubItems.Add(entry.Type);

            if (MainForm.activeConnection && refresh)
            {
                string val = GetValueForEntry(entry, MainForm.activeConnection);
                lvi.SubItems.Add(val);
            }
            else
            {
                lvi.SubItems.Add(entry.Value);
            }

            return lvi;
        }

        private static string GetValueAsString<T>(Func<uint, T> readFunction, CheatEntry entry, int stringLength = 0)
        {
            if (MainForm.activeConnection)
            {
                uint address = uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber);
                return readFunction(address).ToString();
            }

            return string.Empty;
        }

        public static string GetValueForEntry(CheatEntry entry, bool activeConnection)
        {
            string val = "0";
            if (activeConnection)
            {
                if (entry.Type == "Byte") val = GetValueAsString(MainForm.xb.ReadByte, entry);
                else if (entry.Type == "UShort") val = GetValueAsString(MainForm.xb.ReadUInt16, entry);
                else if (entry.Type == "UInt") val = GetValueAsString(MainForm.xb.ReadUInt32, entry);
                else if (entry.Type == "ULong") val = GetValueAsString(MainForm.xb.ReadUInt64, entry);
                else if (entry.Type == "Float") val = GetValueAsString(MainForm.xb.ReadFloat, entry);
                else if (entry.Type == "String") val = MainForm.xb.ReadString(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber), 20);
                else if (entry.Type == "UShortLittleEndian") val = ConversionHelper.ReverseBytes_UInt16(MainForm.xb.ReadUInt16(uint.Parse(entry.Address.Replace("0x", "")))).ToString();
                else if (entry.Type == "UIntLittleEndian") val = ConversionHelper.ReverseBytes_UInt32(MainForm.xb.ReadUInt32(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber))).ToString();
                else if (entry.Type == "ULongLittleEndian") val = ConversionHelper.ReverseBytes_UInt64(MainForm.xb.ReadUInt64(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber))).ToString();
                else if (entry.Type == "Assembly") val = MainForm.xb.ReadUInt32(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber)).ToString("X");
            }
            return val;
        }

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

        public static void RefreshCheatTableValues(ListView cheatTableListView)
        {
            try
            {
                foreach (ListViewItem existingItem in cheatTableListView.Items)
                {
                    CheatEntry entry = GetCheatEntryFromListViewItem(existingItem);

                    if (ShouldSkipEntry(entry))
                        continue;

                    string valueForEntry = GetValueForEntry(entry, MainForm.activeConnection);

                    existingItem.SubItems[3].Text = entry.Value;

                    if (MainForm.activeConnection)
                    {
                        existingItem.SubItems[3].Text = valueForEntry;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }


        private static void LoadJsonData(string filePath, ListView listView, bool refresh)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);

                List<CheatEntry> cheatEntries = JsonConvert.DeserializeObject<List<CheatEntry>>(jsonData);

                listView.Items.Clear();

                foreach (CheatEntry entry in cheatEntries)
                {
                    if (ShouldSkipEntry(entry))
                        continue;
                    if (cheatEntries is null)
                        break;

                    ListViewItem lvi = CreateListViewItem(entry, refresh);
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

        public static void SaveSearchResultsShortList(ListView resultsView)
        {
            try
            {
                if (resultsView.Items.Count == 0)
                {
                    ErrorHelper.Error("You currently don't have any results to save", "Null Entries Error");
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
                    ErrorHelper.Error("You currently don't have any results to save", "Null Entries Error");
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

        public static bool ShouldSkipEntry(CheatEntry entry)
        {
            return string.IsNullOrEmpty(entry.Address) &&
                   string.IsNullOrEmpty(entry.Description) &&
                   string.IsNullOrEmpty(entry.Type) &&
                   string.IsNullOrEmpty(entry.Value);
        }
    }
}

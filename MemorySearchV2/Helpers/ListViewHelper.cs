using DevExpress.XtraEditors;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Windows.Forms;

namespace MemorySearchV2.Helpers
{
    public static class ListViewHelper
    {
        public class CheatEntry
        {
            public string Address { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
        }

        public static ListViewItem CreateListViewItem(uint startAddress, int matchIndex, string value)
        {
            uint matchedAddress = startAddress + (uint)matchIndex;

            ListViewItem lvi = new ListViewItem("0x" + matchedAddress.ToString("X8"));

            lvi.SubItems.Add(value);
            lvi.SubItems.Add(value);

            return lvi;
        }

        public static ListViewItem CreateTableListViewItem(CheatEntry entry, bool refresh)
        {
            ListViewItem lvi = new ListViewItem(entry.Address);
            lvi.SubItems.Add(entry.Description);
            lvi.SubItems.Add(entry.Type);

            if (MainForm.activeConnection && refresh)
            {
                string val = ListViewHelper.GetValueForCheatTableEntry(entry, refresh);
                lvi.SubItems.Add(val);
            }
            else
            {
                lvi.SubItems.Add(entry.Value);
            }

            return lvi;
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

        private static string GetValueAsString<T>(Func<uint, T> readFunction, CheatEntry entry, int stringLength = 0)
        {
            if (MainForm.activeConnection)
            {
                uint address = uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber);
                return readFunction(address).ToString();
            }

            return string.Empty;
        }

        public static string GetValueForCheatTableEntry(CheatEntry entry, bool activeConnection)
        {
            string val = "0";
            if (activeConnection)
            {
                if (entry.Type == "BYTE") val = GetValueAsString(MainForm.xb.ReadByte, entry);
                else if (entry.Type == "USHORT") val = GetValueAsString(MainForm.xb.ReadUInt16, entry);
                else if (entry.Type == "UINT") val = GetValueAsString(MainForm.xb.ReadUInt32, entry);
                else if (entry.Type == "ULONG") val = GetValueAsString(MainForm.xb.ReadUInt64, entry);
                else if (entry.Type == "FLOAT") val = GetValueAsString(MainForm.xb.ReadFloat, entry);
                else if (entry.Type == "STRING") val = MainForm.xb.ReadString(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber), 20);
                else if (entry.Type == "USHORTLITTLEENDIAN") val = ConversionHelper.ReverseBytes_UInt16(MainForm.xb.ReadUInt16(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber))).ToString();
                else if (entry.Type == "UINTLITTLEENDIAN") val = ConversionHelper.ReverseBytes_UInt32(MainForm.xb.ReadUInt32(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber))).ToString();
                else if (entry.Type == "ULONGLITTLEENDIAN") val = ConversionHelper.ReverseBytes_UInt64(MainForm.xb.ReadUInt64(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber))).ToString();
                else if (entry.Type == "ASSEMBLY") val = MainForm.xb.ReadUInt32(uint.Parse(entry.Address.Replace("0x", ""), NumberStyles.HexNumber)).ToString("X");
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
                JsonHelper.LoadJsonData(ofd.FileName, cheatTableListView, refresh);
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

                    string valueForEntry = GetValueForCheatTableEntry(entry, MainForm.activeConnection);

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

        public static bool ShouldSkipEntry(CheatEntry entry)
        {
            return string.IsNullOrEmpty(entry.Address) &&
                   string.IsNullOrEmpty(entry.Description) &&
                   string.IsNullOrEmpty(entry.Type) &&
                   string.IsNullOrEmpty(entry.Value);
        }
    }
}

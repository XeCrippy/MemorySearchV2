using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemorySearchV2.Helpers
{
    class CheatTableConversion
    {
        class DataItem
        {
            public string Address { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
        }

        public void ConvertTableToCsClass()
        {
            XtraOpenFileDialog ofd = new XtraOpenFileDialog
            {
                Title = "Load Xbox 360 Cheat Table",
                Filter = "Xbox 360 Cheat Table (.xct)|*.xct"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string jsonFilePath = ofd.FileName;
                string json = File.ReadAllText(jsonFilePath);
                List<DataItem> dataItems = JsonConvert.DeserializeObject<List<DataItem>>(json);

                string outputPath = "Converted Classes\\" + ofd.SafeFileName.Replace("xct", "cs");
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (var item in dataItems)
                    {
                        writer.WriteLine($"public const uint {SanitizePropertyName(item.Description)} = {item.Address};");
                    }
                }
                ErrorHelper.MessageDialogBox($"C# class constants written to: {outputPath}", "File Converter");
            }
        }

        static string SanitizePropertyName(string propertyName)
        {
            return new string(propertyName.Where(c => char.IsLetterOrDigit(c) || c == '_').ToArray());
        }
    }
}

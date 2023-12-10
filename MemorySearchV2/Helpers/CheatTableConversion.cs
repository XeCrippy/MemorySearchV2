using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static MemorySearchV2.Helpers.ListViewHelper;

namespace MemorySearchV2.Helpers
{
    public class CheatTableConversion
    {
        public void ConvertTableToCsClass()
        {
            XtraOpenFileDialog ofd = new XtraOpenFileDialog
            {
                Title = "Load Xbox 360 Cheat Table",
                Filter = "Xbox 360 Cheat Table (.xct)|*.xct | Json File (.json)|*.json",
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string jsonFilePath = ofd.FileName;
                string json = File.ReadAllText(jsonFilePath);
                string outputPath = "";
                List<CheatEntry> dataItems = JsonConvert.DeserializeObject<List<CheatEntry>>(json);

                if (!Directory.Exists(Application.StartupPath + "\\Converted Classes"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Converted Classes");
                }

                if (ofd.SafeFileName.Contains(".xct"))
                    outputPath = Application.StartupPath +  "\\Converted Classes\\" + ofd.SafeFileName.Replace(".xct", "Helper.cs");
                else if (ofd.SafeFileName.Contains(".json"))
                    outputPath = Application.StartupPath + "\\Converted Classes\\" + ofd.SafeFileName.Replace(".json", "Helper.cs");

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("public class " + ofd.SafeFileName.Replace(".xct", "Helper").Replace(".json", "Helper"));
                    writer.WriteLine("{");
                    int i = 0;
                    foreach (var item in dataItems)
                    {
                        if (string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Description = "result_" + i++.ToString();
                        }
                        writer.WriteLine($"    public const uint {SanitizePropertyName(item.Description)} = {item.Address};");
                    }
                    writer.WriteLine("}");
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

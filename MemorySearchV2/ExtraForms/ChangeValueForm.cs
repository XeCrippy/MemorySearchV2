﻿using MemorySearchV2.Helpers;
using System;
using System.Globalization;

namespace MemorySearchV2.ExtraForms
{
    public partial class ChangeValueForm : DevExpress.XtraEditors.XtraForm
    {
        uint address;
        string datatype;

        public ChangeValueForm(string addr, string type, string value, bool hex = false)
        {
            InitializeComponent();

            Text = addr;
            valueBox.Text = value;
            hexBox.Checked = hex;
            address = uint.Parse(addr.Replace("0x", ""), NumberStyles.HexNumber);
            dataType_.Text = type;
            datatype = type;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkEdit1.Checked)
                {
                    switch (dataType_.Text)
                    {
                        case "Byte":
                            byte val = hexBox.Checked ? byte.Parse(valueBox.Text, NumberStyles.HexNumber) : byte.Parse(valueBox.Text);
                            MainForm.xb.WriteByte(address, hexBox.Checked ? byte.Parse(valueBox.Text, NumberStyles.HexNumber) : byte.Parse(valueBox.Text));
                            break;
                        case "UShort":
                            MainForm.xb.WriteUInt16(address, hexBox.Checked ? ushort.Parse(valueBox.Text, NumberStyles.HexNumber) : ushort.Parse(valueBox.Text));
                            break;
                        case "UInt":
                            MainForm.xb.WriteUInt32(address, hexBox.Checked ? uint.Parse(valueBox.Text, NumberStyles.HexNumber) : uint.Parse(valueBox.Text));
                            break;
                        case "ULong":
                            MainForm.xb.WriteUInt64(address, hexBox.Checked ? ulong.Parse(valueBox.Text, NumberStyles.HexNumber) : ulong.Parse(valueBox.Text));
                            break;
                        case "Float":
                            MainForm.xb.WriteFloat(address, hexBox.Checked ? float.Parse(valueBox.Text, NumberStyles.HexNumber) : float.Parse(valueBox.Text));
                            break;
                        case "String":
                            MainForm.xb.WriteString(address, valueBox.Text);
                            break;
                        default:
                            ErrorHelper.MessageDialogBox("You must select a data type", "Invalid Data Type");
                            break;
                    }
                }
                else
                {
                    switch(dataType_.Text)
                    {
                        case "UShort":
                            ushort num  = hexBox.Checked ? ushort.Parse(valueBox.Text, NumberStyles.HexNumber) : ushort.Parse(valueBox.Text);
                            MainForm.xb.WriteUInt16(address, ConversionHelper.ReverseBytes_UInt16(num));
                            break;
                        case "UInt":
                            uint num1 = hexBox.Checked ? uint.Parse(valueBox.Text, NumberStyles.HexNumber) : uint.Parse(valueBox.Text);
                            MainForm.xb.WriteUInt32(address, ConversionHelper.ReverseBytes_UInt32(num1));
                            break;
                        case "ULong":
                            ulong num2 = hexBox.Checked ? ulong.Parse(valueBox.Text, NumberStyles.HexNumber) : ulong.Parse(valueBox.Text);
                            MainForm.xb.WriteUInt64(address, ConversionHelper.ReverseBytes_UInt64(num2));
                            break;
                    }
                }
                Close();
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
using MemorySearchV2.Helpers;
using System;
using System.Windows.Forms;

namespace MemorySearchV2.ExtraForms
{
    public partial class AddEntryForm : DevExpress.XtraEditors.XtraForm
    {
        public AddEntryForm(string addr = "", string description = "", string value = "", string type = "")
        {
            InitializeComponent();
            AddressBox.Focus();
            AddressBox.Text = addr;
            DescriptionBox.Text = description;
            valueBox.Text = value;
            TypeBox.Text = type;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(AddressBox.Text);
            lvi.SubItems.Add(DescriptionBox.Text);
            lvi.SubItems.Add(TypeBox.Text);
            lvi.SubItems.Add(valueBox.Text);
            MainForm.extlvi = lvi;
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
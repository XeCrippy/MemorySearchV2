
namespace MemorySearchV2.ExtraForms
{
    partial class AddEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEntryForm));
            this.TypeBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.DescriptionBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.AddressBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.valueBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TypeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TypeBox
            // 
            this.TypeBox.Location = new System.Drawing.Point(79, 90);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Properties.Appearance.Options.UseTextOptions = true;
            this.TypeBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TypeBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TypeBox.Properties.Items.AddRange(new object[] {
            "Byte",
            "UShort",
            "UInt",
            "ULong",
            "Float"});
            this.TypeBox.Size = new System.Drawing.Size(100, 20);
            this.TypeBox.TabIndex = 24;
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(104, 116);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 23;
            this.simpleButton2.Text = "Cancel";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(20, 116);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 22;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(79, 38);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Properties.Appearance.Options.UseTextOptions = true;
            this.DescriptionBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DescriptionBox.Size = new System.Drawing.Size(100, 20);
            this.DescriptionBox.TabIndex = 21;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(49, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Type";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Description";
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(79, 12);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Properties.Appearance.Options.UseTextOptions = true;
            this.AddressBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AddressBox.Properties.MaxLength = 8;
            this.AddressBox.Properties.NullValuePrompt = "Ex: 0x82000000";
            this.AddressBox.Size = new System.Drawing.Size(100, 20);
            this.AddressBox.TabIndex = 18;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Address";
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(79, 64);
            this.valueBox.Name = "valueBox";
            this.valueBox.Properties.Appearance.Options.UseTextOptions = true;
            this.valueBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.valueBox.Size = new System.Drawing.Size(100, 20);
            this.valueBox.TabIndex = 25;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(47, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Value";
            // 
            // AddEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 157);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.valueBox);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("AddEntryForm.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Entry";
            ((System.ComponentModel.ISupportInitialize)(this.TypeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit TypeBox;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit DescriptionBox;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit AddressBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit valueBox;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
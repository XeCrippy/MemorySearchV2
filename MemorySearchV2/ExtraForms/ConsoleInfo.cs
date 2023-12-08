using DevExpress.LookAndFeel;
using MemorySearchV2.Helpers;
using System;

namespace MemorySearchV2.ExtraForms
{
    public partial class ConsoleInfo : DevExpress.XtraEditors.XtraForm
    {
        bool isDevkit = Properties.Settings.Default.IsDevKit;
        private readonly uint XAMXuidRetail = 0x81AA291C;

        public ConsoleInfo()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Black", "Fire Brick");
        }

        private void ConsoleInfo_Load(object sender, EventArgs e)
        {
            try
            {
                if (MainForm.activeConnection)
                {
                    XboxIPBox.Text = MainForm.xb.XboxIP();
                    CpuKeyBox.Text = MainForm.xb.GetCPUKey();
                    ConsoleIdBox.Text = MainForm.xb.GetConsoleID();
                    XboxNameBox.Text = MainForm.xb.Name;
                    TitleIdBox.Text = MainForm.xb.XamGetCurrentTitleId().ToString("X8");
                    MotherboardBox.Text = MainForm.xb.ConsoleType().ToString() + " : " + MainForm.xb.ConsoleType.ToString();
                    FeaturesBox.Text = MainForm.xb.ConsoleFeatures.ToString();
                    DbgVersionBox.Text = MainForm.xb.GetDebugVersion();
                    KernelVersionBox.Text = "2.0." + MainForm.xb.GetKernalVersion().ToString() + ".0";
                    GamertagBox.Text = MainForm.xb.GetGamertag(isDevkit);
                    ProfileIdBox.Text = MainForm.xb.GetOfflineXuidDevKit(isDevkit).ToString("X");
                    XuidBox.Text = "Not implemented for devkit";
                    if (!isDevkit)
                        XuidBox.Text = MainForm.xb.ReadUInt64(XAMXuidRetail).ToString("X");
                }
                else ErrorHelper.ConnectionError();
            }
            catch(Exception ex)
            {
                ErrorHelper.Error(ex);
            }
        }
    }
}
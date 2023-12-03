using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace MemorySearchV2.Helpers
{
    public static class ErrorHelper
    {
        private static readonly string logFilePath = "logs\\error_log.txt";
        private static readonly string resultsFilePath = "logs\\search_info.txt";

        private static void CheckValidDirectory()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string logDirectory = Path.Combine(directory, "logs");

            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);
        }

        public static void ConnectionError()
        {
            string[] lines=
            {
                "You are not connected to your console", "Null Connection Error"
            };
            MessageDialogBox(lines[0], lines[1]);
            Array.Reverse(lines);
            LogMessages(lines, logFilePath);
        }

        public static void DisplaySearchResultsMsg(int foundMatches, long searchTimer)
        {
            string[] lines =
            {
                   new string('-', 80) ,  "Successfully found : " + foundMatches + " matches" + "\nSearch Time : " + searchTimer.ToString() + " seconds"
            };

            long elapsedMilliseconds = searchTimer;
            int hours = (int)(elapsedMilliseconds / (1000 * 60 * 60));
            int minutes = (int)((elapsedMilliseconds % (1000 * 60 * 60)) / (1000 * 60));
            int seconds = (int)((elapsedMilliseconds % (1000 * 60)) / 1000);
            int milliseconds = (int)(elapsedMilliseconds % 1000);

            string elapsedTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}:{milliseconds:D3}";
           
            MessageDialogBox($"Successfully found: {foundMatches} matches\n\nSearch Time: {elapsedTime}", "Search Results");

            LogMessages(lines, resultsFilePath);
        }

        public static void Error(string message, string caption = "An error has occured")
        {
            XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            string[] _lines =
            {
                caption, message
            };
            LogMessages(_lines, logFilePath);
        }

        public static void Error(Exception ex)
        {
            string[] lines = { "Member name : " + ex.GetType().Name + "\n" + "Error Message : " + ex.Message + "\n" + ex.TargetSite.ToString() , ex.Source.ToUpperInvariant() };
            XtraMessageBox.Show(lines[0], lines[1], MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogError(ex);
        }

        private static void LogError(Exception ex)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string logFileFullPath = Path.Combine(directory, logFilePath);

            CheckValidDirectory();
            string[] lines =
            {
                $"[{DateTime.Now}] Error in {ex.Source}: {ex.Message}", 
                $"TargetSite: {ex.TargetSite}", new string('-', 80)
            };

            File.AppendAllLines(logFileFullPath, lines);
        }

        private static void LogMessages(string[] lines, string filePath)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string logFileFullPath = Path.Combine(directory, filePath);

            CheckValidDirectory();
            Array.Reverse(lines);
            File.AppendAllLines(logFileFullPath, lines);
        }

        public static void MessageDialogBox(string message, string caption, MessageBoxButtons buttons=MessageBoxButtons.OK, MessageBoxIcon icon=MessageBoxIcon.Information)
        {
            XtraMessageBox.Show(message, caption, buttons, icon);
        }
    }
}

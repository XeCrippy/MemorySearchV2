using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorySearchV2.Helpers
{
    public static class SettingsHelper
    {
        /// <summary>
        /// currently unused
        /// </summary>
        /// <param name="resultsToDisplay"></param>
        /// <param name="address"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <param name="dataType"></param>
        /// <param name="ishex"></param>
        /// <param name="littleEndian"></param>
        /// <param name="pauseWhileSearching"></param>
        /// <param name="refreshInterval"></param>
        /// <param name="autoConnect"></param>
        public static void LoadProgramSettings(ref int resultsToDisplay, ref string address, ref string size, ref string value, ref string dataType, ref bool ishex, ref bool littleEndian, ref bool pauseWhileSearching, ref int refreshInterval, ref bool autoConnect)
        {
            resultsToDisplay = Properties.Settings.Default.ResultsToDisplay;
            address = Properties.Settings.Default.PreviousStartAddress;
            size = Properties.Settings.Default.PreviousEndAddress;
            value = Properties.Settings.Default.PreviousValue;
            dataType = Properties.Settings.Default.PreviousDataType;
            ishex = Properties.Settings.Default.IsHexValue;
            littleEndian = Properties.Settings.Default.IsLittleEndianValue;
            pauseWhileSearching = Properties.Settings.Default.PauseWhileSearching;
            refreshInterval = Properties.Settings.Default.RefreshTableValuesInterval;
            autoConnect = Properties.Settings.Default.AutoConnect;
        }

        /// <summary>
        /// currently unused
        /// </summary>
        /// <param name="resultsToDisplay"></param>
        /// <param name="address"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <param name="dataType"></param>
        /// <param name="ishex"></param>
        /// <param name="littleEndian"></param>
        /// <param name="pauseWhileSearching"></param>
        /// <param name="refreshInterval"></param>
        /// <param name="autoConnect"></param>
        public static void SaveProgramSettings(ref int resultsToDisplay, ref string address, ref string size, ref string value, ref string dataType, ref bool ishex, ref bool littleEndian, ref bool pauseWhileSearching, ref int refreshInterval, ref bool autoConnect)
        {

        }
    }
}

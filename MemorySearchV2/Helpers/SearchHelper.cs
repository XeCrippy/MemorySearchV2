using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemorySearchV2.Helpers
{
    public static class SearchHelper
    {
        private static int foundMatches;
        public static List<ListViewItem> searchResults = new List<ListViewItem>();

        public static byte[] GetSearchParameters(string type, string value, bool isHex, bool LittleEndian, out int searchSize)
        {
            try
            {
                searchSize = 0;
                byte[] searchValue = null;

                string data_type = type;

                if (data_type == "BYTE")
                {
                    searchSize = 1;
                    searchValue =  new byte[] { byte.Parse(value.Replace("0x", ""), NumberStyles.HexNumber) };
                }
                else if (data_type == "USHORT")
                {
                    searchSize = 2;
                    if (isHex == true) searchValue = BitConverter.GetBytes(ushort.Parse(value.Replace("0x", ""), NumberStyles.HexNumber));
                    else searchValue = BitConverter.GetBytes(ushort.Parse(value));
                    if (!LittleEndian) Array.Reverse(searchValue);
                }
                else if (data_type == "UINT")
                {
                    searchSize = 4;
                    if (isHex) searchValue = BitConverter.GetBytes(uint.Parse(value.Replace("0x", ""), NumberStyles.HexNumber));
                    else searchValue = BitConverter.GetBytes(uint.Parse(value));
                    if (!LittleEndian) Array.Reverse(searchValue);
                }
                else if (data_type == "ULONG")
                {
                    searchSize = 8;
                    if (isHex) searchValue = BitConverter.GetBytes(ulong.Parse(value.Replace("0x", ""), NumberStyles.HexNumber));
                    else searchValue = BitConverter.GetBytes(ulong.Parse(value));
                    if (!LittleEndian) Array.Reverse(searchValue);
                }
                else if (data_type == "FLOAT")
                {
                    searchSize = 4;
                    searchValue = BitConverter.GetBytes(float.Parse(value));
                    if (BitConverter.IsLittleEndian) Array.Reverse(searchValue);
                }
                else if (data_type == "STRING")
                {
                    searchSize = value.Length;
                    searchValue = Encoding.ASCII.GetBytes(value);
                }

                return searchValue;
            }
            catch (Exception ex)
            {

                ErrorHelper.Error(ex);
                searchSize = 0;
                return new byte[] { 0 };
            }
        }

        private static void IncrementFoundMatches(int maxEntries)
        {
            Interlocked.Increment(ref foundMatches);

            if (foundMatches >= maxEntries)
                return;
        }

        public static byte[] PerformInitialMemoryDump(uint startAddress, uint length)
        {
            try
            {
                byte[] bytes = MainForm.xb.GetMemory2(startAddress, length, 0x10000);

                return bytes;
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
                return null;
            }
        }

        public static List<ListViewItem> PerformMemorySearchParallel(string startAddressBox, string endAddressBox, string value, int searchSize, byte[] searchValue, bool pauseWhileSearching, SplashScreenManager splashScreenManager, uint ChunkSize, int maxResults = int.MaxValue)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                splashScreenManager.ShowWaitForm();

                foundMatches = 0;

                uint start = uint.Parse(startAddressBox, NumberStyles.HexNumber);
                uint end = uint.Parse(endAddressBox, NumberStyles.HexNumber);
                uint length = SearchLength(start, end);

                stopwatch.Start();

                if (pauseWhileSearching)
                    MainForm.xb.DebugTarget.Stop(out bool isStopped);

                byte[] bytes = MainForm.xb.GetMemoryTest(start, length, ChunkSize);

                int[] badCharShift = new int[Byte.MaxValue + 1];
                int lastChar = searchSize - 1;

                PreprocessBadCharShift(searchSize, searchValue, badCharShift, lastChar);

                Parallel.ForEach(Partitioner.Create(0, (int)length), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                    range => SearchMemoryRange(range, bytes, searchSize, searchValue, value, maxResults, start, badCharShift));

                if (pauseWhileSearching)
                    MainForm.xb.DebugTarget.Go(out bool isStopped);

                stopwatch.Stop();
                long searchTimer = stopwatch.ElapsedMilliseconds;
                if (splashScreenManager.IsSplashFormVisible)
                    splashScreenManager.CloseWaitForm();
                ErrorHelper.DisplaySearchResultsMsg(foundMatches, searchTimer);

                return searchResults;
            }
            catch (Exception ex)
            {
                if (splashScreenManager.IsSplashFormVisible)
                    splashScreenManager.CloseWaitForm();
                ErrorHelper.Error(ex);
                return null;
            }
        }

        private static int[] PreprocessBadCharShift(int searchSize, byte[] searchValue, int[] badCharShift, int lastChar)
        {
            for (int k = 0; k < 256; k++)
                badCharShift[k] = searchSize;

            for (int k = 0; k < lastChar; k++)
                badCharShift[searchValue[k]] = lastChar - k;

            return badCharShift;
        }

        private static uint SearchLength(uint start, uint end)
        {
            if (start > end)
                return start - end;
            else
                return end - start;
        }

        private static void SearchMemoryRange(Tuple<int, int> range, byte[] bytes, int searchSize, byte[] searchValue, string value, int maxResults, uint start, int[] badCharShift)
        {
            List<ListViewItem> localSearchResults = new List<ListViewItem>();

            for (int i = (int)range.Item1; i < range.Item2 - searchSize;)
            {
                int j = searchSize - 1;
                int matchIndex = i;

                while (j >= 0 && searchValue[j] == bytes[matchIndex + j])
                    j--;

                if (j < 0)
                {
                    // Match found
                    ListViewItem lvi = ListViewHelper.CreateListViewItem(start, matchIndex, value);
                    localSearchResults.Add(lvi);
                    IncrementFoundMatches(maxResults);
                    i = matchIndex + searchSize; 
                }
                else
                {
                   i += Math.Max(1, badCharShift[bytes[i + j]] - (searchSize - 1 - j));
                   if (localSearchResults.Count < 0)
                        localSearchResults.RemoveAt(matchIndex);
                }
            }

            lock (searchResults)
            {
                searchResults.AddRange(localSearchResults);
            }
        }

        public static bool ValidateUserInputs(string addrBox, string sizeBox, string valueBox, string dataType, bool isHex)
         {
             if (string.IsNullOrWhiteSpace(addrBox) || string.IsNullOrWhiteSpace(sizeBox) || string.IsNullOrWhiteSpace(valueBox) || string.IsNullOrWhiteSpace(dataType))
             {
                 ErrorHelper.MessageDialogBox("Please enter valid values for address, size, value, and data type.", "Input Error");
                 return false;
             }
             if (isHex)
             {
                 if (long.TryParse(valueBox, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _))
                 {
                     return true;
                 }
                 else
                 {
                     ErrorHelper.MessageDialogBox("Please enter valid hex value or uncheck the 'Search Hex' box.", "Input Error");
                     return false;
                 }
             }
             else if (dataType == "String")
             {
                return true;
             }
             else
             {
                if (long.TryParse(valueBox, out _))
                {
                     return true;
                }
                 else
                 {
                     ErrorHelper.MessageDialogBox("Please enter valid integer value or check the 'Search Hex' box.", "Input Error");
                     return false;
                 }
             }
         }
    }
}

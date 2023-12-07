using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
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

                switch (data_type)
                {
                    case "BYTE":
                        searchSize = 1;
                        searchValue = new byte[] { byte.Parse(value.Replace("0x", ""), NumberStyles.HexNumber) };
                        break;
                    case "USHORT":
                        searchSize = 2;
                        if (isHex == true) searchValue = BitConverter.GetBytes(ushort.Parse(value.Replace("0x", ""), NumberStyles.HexNumber));
                        else searchValue = BitConverter.GetBytes(ushort.Parse(value));
                        if (!LittleEndian) Array.Reverse(searchValue);
                        break;
                    case "UINT":
                        searchSize = 4;
                        if (isHex) searchValue = BitConverter.GetBytes(uint.Parse(value.Replace("0x", ""), NumberStyles.HexNumber));
                        else searchValue = BitConverter.GetBytes(uint.Parse(value));
                        if (!LittleEndian) Array.Reverse(searchValue);
                        break;
                    case "ULONG":
                        searchSize = 8;
                        if (isHex) searchValue = BitConverter.GetBytes(ulong.Parse(value.Replace("0x", ""), NumberStyles.HexNumber));
                        else searchValue = BitConverter.GetBytes(ulong.Parse(value));
                        if (!LittleEndian) Array.Reverse(searchValue);
                        break;
                    case "FLOAT":
                        searchSize = 4;
                        searchValue = BitConverter.GetBytes(float.Parse(value));
                        if (BitConverter.IsLittleEndian) Array.Reverse(searchValue);
                        break;
                    case "STRING":
                        searchSize = value.Length;
                        searchValue = Encoding.ASCII.GetBytes(value);
                        break;
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
                byte[] bytes = MainForm.xb.GetMemoryTest(startAddress, length, 0x10000);

                return bytes;
            }
            catch (Exception ex)
            {
                ErrorHelper.Error(ex);
                return null;
            }
        }

        public static List<ListViewItem> PerformInitialSeach(string startAddressBox, string endAddressBox, string value, int searchSize, byte[] searchValue, bool pauseWhileSearching, SplashScreenManager splashScreenManager, uint ChunkSize, int maxResults = int.MaxValue)
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

        private static uint NextSearchStartAddress()
        {
            uint start;
            uint first = uint.Parse(searchResults.First().Text.Replace("0x", ""), NumberStyles.HexNumber);
            uint last = uint.Parse(searchResults.Last().Text.Replace("0x", ""), NumberStyles.HexNumber);

            if (first < last)
            {
                start = uint.Parse(searchResults.First().Text.Replace("0x", ""), NumberStyles.HexNumber);
            }
            else 
            {
                start = uint.Parse(searchResults.Last().Text.Replace("0x", ""), NumberStyles.HexNumber);
            }
            return start;
        }

        /// <summary>
        /// WORK IN PROGRESS
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="pauseWhileSearching"></param>
        /// <param name="splashScreenManager"></param>
        /// <param name="ChunkSize"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public static List<ListViewItem> PerformSubsequentSearches(string value, int searchSize, byte[] searchValue, bool pauseWhileSearching, SplashScreenManager splashScreenManager, uint ChunkSize, int maxResults = int.MaxValue)
        {
            /* try
             {
                 Stopwatch stopwatch = new Stopwatch();
                 splashScreenManager.ShowWaitForm();
                 foundMatches = 0;
                 uint length = (uint)searchResults.Count * 4;

                 stopwatch.Start();

                 if (pauseWhileSearching)
                     MainForm.xb.DebugTarget.Stop(out bool isStopped);

                 byte[] bytes = MainForm.xb.GetMemoryTest(NextSearchStartAddress(), length, ChunkSize);

                 int[] badCharShift = new int[Byte.MaxValue + 1];
                 int lastChar = searchSize - 1;

                 PreprocessBadCharShift(searchSize, searchValue, badCharShift, lastChar);

                 Parallel.ForEach(Partitioner.Create(0, (int)length), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                     range => SearchMemoryRange(range, bytes, searchSize, searchValue, value, maxResults, NextSearchStartAddress(), badCharShift));

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
             }*/
            return null;
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

        // there may be some redundencies here but it's working so i left it for right now
        public static void PerformFollowUpSearches(bool pause, ListView resultList, string dataType_, string valBox, bool isHex, bool isLittleEndian, int resultsToDisplay, SplashScreenManager splashScreenManager1)
        {
            try
            {
                if (pause)
                    MainForm.xb.DebugTarget.Stop(out bool isStopped);

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                splashScreenManager1.ShowWaitForm();

                ListView.ListViewItemCollection list = resultList.Items;
                List<ListViewItem> itemsToAdd = new List<ListViewItem>();

                int searchSize;
                byte[] searchValue = SearchHelper.GetSearchParameters(dataType_, valBox, isHex, isLittleEndian, out searchSize);

                int found = 0;

                string previousValue = resultList.Items[0].SubItems[1].Text;
                Parallel.ForEach(searchResults, resultItem =>
                {
                    uint address = uint.Parse(resultItem.Text.Replace("0x", ""), NumberStyles.HexNumber);
                    byte[] buffer = MainForm.xb.GetMemory(address, (uint)searchSize);

                    if (buffer.SequenceEqual(searchValue))
                    {
                        ListViewItem lvi = new ListViewItem("0x" + address.ToString("X8"));
                        lvi.SubItems.Add((string)valBox.Clone());
                        lvi.SubItems.Add(previousValue);
                        lock (itemsToAdd)
                        {
                            itemsToAdd.Add(lvi);
                        }
                        Interlocked.Increment(ref found);
                    }
                    else
                    {
                        // Remove invalid result from the list
                        lock (itemsToAdd)
                        {
                            itemsToAdd.Remove(resultItem);
                        }
                    }
                });

                resultList.Items.Clear();
                resultList.Items.AddRange(itemsToAdd.Take(resultsToDisplay).ToArray());

                if (found == 0)
                {
                    resultList.Items.Clear(); // Clear the list if no valid results are found
                    searchResults.Clear();
                }

                if (pause)
                    MainForm.xb.DebugTarget.Go(out bool isStopped);

                stopwatch.Stop();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();

                ErrorHelper.DisplaySearchResultsMsg(found, elapsedMilliseconds);
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
                ErrorHelper.Error(ex);
            }
        }


        // there may be some redundencies here but it's working so i left it for right now
        public static void PerformFollowUpSearchesForChangedValues(bool pause, ListView resultList, string dataType_,  bool isHex, bool isLittleEndian, int resultsToDisplay, SplashScreenManager splashScreenManager1)
        {
            try
            {
                if (pause)
                    MainForm.xb.DebugTarget.Stop(out bool isStopped);

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                splashScreenManager1.ShowWaitForm();

                int searchSize;
                byte[] searchValue = SearchHelper.GetSearchParameters(dataType_, resultList.Items[0].SubItems[1].Text, isHex, isLittleEndian, out searchSize); // search checks against the value in the value column of the resultList

                int found = 0;
                

                ListView.ListViewItemCollection list = resultList.Items;
                List<ListViewItem> itemsToAdd = new List<ListViewItem>();
                string previousValue = resultList.Items[0].SubItems[1].Text;

                Parallel.ForEach(searchResults, resultItem =>
                {
                    uint address = uint.Parse(resultItem.Text.Replace("0x", ""), NumberStyles.HexNumber);
                    byte[] buffer = MainForm.xb.GetMemory(address, (uint)searchSize);

                    if (!buffer.SequenceEqual(searchValue))
                    {
                        string convertedValue = ConversionHelper.ConvertBytes(buffer, dataType_, !isLittleEndian);
                        ListViewItem lvi = new ListViewItem("0x" + address.ToString("X8"));
                        lvi.SubItems.Add(convertedValue);
                        lvi.SubItems.Add(previousValue);
                        itemsToAdd.Add(lvi);
                        Interlocked.Increment(ref found);
                    }
                    else
                    {
                        // Remove invalid result from the list
                        lock (itemsToAdd)
                        {
                            itemsToAdd.Remove(resultItem);
                        }
                    }
                });

                resultList.Items.Clear();
                resultList.Items.AddRange(itemsToAdd.Take(resultsToDisplay).ToArray());

                if (found == 0)
                {
                    resultList.Items.Clear(); // Clear the list if no valid results are found
                    SearchHelper.searchResults.Clear();
                }

                if (pause)
                    MainForm.xb.DebugTarget.Go(out bool isStopped);

                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();

                stopwatch.Stop();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                ErrorHelper.DisplaySearchResultsMsg(found, elapsedMilliseconds);
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
                ErrorHelper.Error(ex);
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
             else if (dataType == "STRING")
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

using System;
using System.Text;
using System.Threading.Tasks;
using XDevkit;

namespace MemorySearchV2.Helpers
{
    public static class JRPC
    {
        public static uint connectionId;

        public static bool Connect(this IXboxConsole console, out IXboxConsole Console, string XboxNameOrIP = "default")
        {
            if (XboxNameOrIP == "default")
                XboxNameOrIP = ((IXboxManager)new XboxManager()).DefaultConsole;
            IXboxConsole xboxConsole = (IXboxConsole)((IXboxManager)new XboxManager()).OpenConsole(XboxNameOrIP);
            bool flag = false;
            while (!flag)
            {
                try
                {
                    connectionId = xboxConsole.OpenConnection((string)null);
                    flag = true;
                }
                catch
                {
                    Console = xboxConsole;
                    return false;
                }
            }
            Console = xboxConsole;
            return true;
        }

        public static byte[] GetMemory(this IXboxConsole console, uint Address, uint Length)
        {
            byte[] Data = new byte[(int)(IntPtr)Length];
            console.DebugTarget.GetMemory(Address, Length, Data, out uint BytesRead);
            console.DebugTarget.InvalidateMemoryCache(true, Address, Length);
            return Data;
        }

        private static  byte[] GetMemory1(this IXboxConsole console, uint Address, uint Length)
        {
            byte[] Data = new byte[(int)(IntPtr)Length];
            console.DebugTarget.GetMemory(Address, Length, Data, out uint BytesRead);
            return Data;
        }

        public static byte[] GetMemory2(this IXboxConsole console, uint address, uint length, uint ChunkSize=0x10000)
        {
            byte[] result = new byte[length];

            for (uint offset = 0; offset < length; offset += ChunkSize)
            {
                uint chunkLength = Math.Min(ChunkSize, length - offset);
                byte[] chunk = console.GetMemory1(address + offset, chunkLength);
                Buffer.BlockCopy(chunk, 0, result, (int)offset, (int)chunkLength);
            }
            console.DebugTarget.InvalidateMemoryCache(true, address, length);
            return result;
        }

        public static byte[] GetMemoryTest(this IXboxConsole console, uint address, uint length, uint ChunkSize = 0x10000) // you can adjust this based on search length....i think
        {
            byte[] result = new byte[length];
            object lockObject = new object();

            Parallel.For(0, (int)Math.Ceiling((double)length / ChunkSize), new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                i =>
                {
                    uint offset = (uint)(i * ChunkSize);
                    uint chunkLength = Math.Min(ChunkSize, length - offset);
                    byte[] chunk = console.GetMemory1(address + offset, chunkLength);

                    lock (lockObject)
                    {
                        Buffer.BlockCopy(chunk, 0, result, (int)offset, (int)chunkLength);
                    }
                });

            console.DebugTarget.InvalidateMemoryCache(true, address, length);
            return result;
        }

        public static void Push(this byte[] InArray, out byte[] OutArray, byte Value)
        {
            OutArray = new byte[InArray.Length + 1];
            InArray.CopyTo((Array)OutArray, 0);
            OutArray[InArray.Length] = Value;
        }

        public static float ReadFloat(this IXboxConsole console, uint Address)
        {
            byte[] memory = console.GetMemory2(Address, 4U);
            ReverseBytes(memory, 4);
            return BitConverter.ToSingle(memory, 0);
        }

        public static byte ReadByte(this IXboxConsole console, uint Address)
        {
            return console.GetMemory2(Address, 1U)[0];
        }

        public static string ReadString(this IXboxConsole console, uint Address, uint size)
        {
            return Encoding.UTF8.GetString(console.GetMemory2(Address, size));
        }

        public static ushort ReadUInt16(this IXboxConsole console, uint Address)
        {
            byte[] memory = console.GetMemory2(Address, 2U);
            ReverseBytes(memory, 2);
            return BitConverter.ToUInt16(memory, 0);
        }

        public static uint ReadUInt32(this IXboxConsole console, uint Address)
        {
            byte[] memory = console.GetMemory2(Address, 4U);
            ReverseBytes(memory, 4);
            return BitConverter.ToUInt32(memory, 0);
        }

        public static ulong ReadUInt64(this IXboxConsole console, uint Address)
        {
            byte[] memory = console.GetMemory2(Address, 8U);
            ReverseBytes(memory, 8);
            return BitConverter.ToUInt64(memory, 0);
        }

        private static void ReverseBytes(byte[] buffer, int groupSize)
        {
            if (buffer.Length % groupSize != 0)
                throw new ArgumentException("Group size must be a multiple of the buffer length");
            int num1 = 0;
            while (num1 < buffer.Length)
            {
                int index1 = num1;
                for (int index2 = num1 + groupSize - 1; index1 < index2; --index2)
                {
                    byte num2 = buffer[index1];
                    buffer[index1] = buffer[index2];
                    buffer[index2] = num2;
                    ++index1;
                }
                num1 += groupSize;
            }
        }

        public static void SetMemory(this IXboxConsole console, uint Address, byte[] Data)
        {
            uint BytesWritten;
            console.DebugTarget.SetMemory(Address, (uint)Data.Length, Data, out BytesWritten);
        }

        public static void WriteByte(this IXboxConsole console, uint Address, byte Value)
        {
            console.SetMemory(Address, new byte[1] { Value });
        }

        public static void WriteByte(this IXboxConsole console, uint Address, byte[] Value)
        {
            console.SetMemory(Address, Value);
        }

        public static void WriteFloat(this IXboxConsole console, uint Address, float Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            Array.Reverse((Array)bytes);
            console.SetMemory(Address, bytes);
        }

        public static void WriteUInt16(this IXboxConsole console, uint Address, ushort Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            ReverseBytes(bytes, 2);
            console.SetMemory(Address, bytes);
        }

        public static void WriteUInt32(this IXboxConsole console, uint Address, uint Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            ReverseBytes(bytes, 4);
            console.SetMemory(Address, bytes);
        }

        public static void WriteUInt64(this IXboxConsole console, uint Address, ulong Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            ReverseBytes(bytes, 8);
            console.SetMemory(Address, bytes);
        }

        public static void WriteString(this IXboxConsole console, uint Address, string String)
        {
            byte[] OutArray = new byte[0];
            foreach (byte num in String)
                OutArray.Push(out OutArray, num);
            OutArray.Push(out OutArray, (byte)0);
            console.SetMemory(Address, OutArray);
        }
    }
}

using System;
using System.Text;

namespace MemorySearchV2.Helpers
{
    public static class ConversionHelper
    {
        public static string ConvertBytes(byte[] bytes, string dataType, bool islittleendian)
        {
            if (islittleendian)
            {
                switch (dataType)
                {
                    case "BYTE":
                        Array.Reverse(bytes);
                        return bytes[0].ToString();
                    case "USHORT":
                        return ReverseBytes_UInt16(BitConverter.ToUInt16(bytes, 0)).ToString();
                    case "UINT":
                        return ReverseBytes_UInt32(BitConverter.ToUInt32(bytes, 0)).ToString();
                    case "ULONG":
                        return ReverseBytes_UInt64(BitConverter.ToUInt64(bytes, 0)).ToString();
                    case "FLOAT":
                        return ReverseBytes_Float(BitConverter.ToSingle(bytes, 0)).ToString();
                    case "STRING":
                        Array.Reverse(bytes);
                        return Encoding.UTF8.GetString(bytes);
                    case "SHORT":
                        return ReverseBytes_Int16(BitConverter.ToInt16(bytes, 0)).ToString();
                    case "INT":
                        return ReverseBytes_Int32(BitConverter.ToInt32(bytes, 0)).ToString();
                    case "LONG":
                        return ReverseBytes_Int64(BitConverter.ToInt64(bytes, 0)).ToString();
                    case "DOUBLE":
                        return BitConverter.ToDouble(bytes, 0).ToString();
                    default:
                        throw new ArgumentException("Unsupported data type", nameof(dataType));
                }
            }

            switch (dataType)
            {
                case "BYTE":

                    return bytes[0].ToString();
                case "USHORT":
                    return BitConverter.ToUInt16(bytes, 0).ToString();
                case "UINT":
                    return BitConverter.ToUInt32(bytes, 0).ToString();
                case "ULONG":
                    return BitConverter.ToUInt64(bytes, 0).ToString();
                case "FLOAT":
                    return BitConverter.ToSingle(bytes, 0).ToString();
                case "STRING":
                    return Encoding.UTF8.GetString(bytes);
                case "SHORT":
                    return BitConverter.ToInt16(bytes, 0).ToString();
                case "INT":
                    return BitConverter.ToInt32(bytes, 0).ToString();
                case "LONG":
                    return BitConverter.ToInt64(bytes, 0).ToString();
                case "DOUBLE":
                    return BitConverter.ToDouble(bytes, 0).ToString();
                default:
                    throw new ArgumentException("Unsupported data type", nameof(dataType));
            }
        }

        public static string ElapsedTime(long elapsedMilliseconds)
        {
            int hours = (int)(elapsedMilliseconds / (1000 * 60 * 60));
            int minutes = (int)((elapsedMilliseconds % (1000 * 60 * 60)) / (1000 * 60));
            int seconds = (int)((elapsedMilliseconds % (1000 * 60)) / 1000);
            int milliseconds = (int)(elapsedMilliseconds % 1000);

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}:{milliseconds:D3}";
        }

        public static UInt16 ReverseBytes_UInt16(UInt16 value)
        {
            return (ushort)((value & 0x00FF) << 8 | (value & 0xFF00) >> 8);
        }

        public static UInt32 ReverseBytes_UInt32(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 |      // Move the first byte to the last byte
                   (value & 0x0000FF00U) << 8 |      // Move the second byte to the third byte
                   (value & 0x00FF0000U) >> 8 |      // Move the third byte to the second byte
                   (value & 0xFF000000U) >> 24;       // Move the last byte to the first byte
        }

        public static UInt64 ReverseBytes_UInt64(UInt64 value)
        {
            return (value & 0x00000000000000FFUL) << 56 |
                   (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 |
                   (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 |
                   (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 |
                   (value & 0xFF00000000000000UL) >> 56;
        }

        public static Int16 ReverseBytes_Int16(Int16 value)
        {
            return (Int16)((value & 0x00FF) << 8 | (value & 0xFF00) >> 8);
        }

        public static Int32 ReverseBytes_Int32(Int32 value)
        {
            return (value & 0x000000FF) << 24 |
                (value & 0x0000FF00) << 8 |
                (value & 0x00FF0000) >> 8 |
                (value & 0x7F000000) >> 24;
        }

        public static Int64 ReverseBytes_Int64(Int64 value)
        {
            return (value & 0x00000000000000FFL) << 56 | 
                (value & 0x000000000000FF00L) << 40 |
                (value & 0x0000000000FF0000L) << 24 | 
                (value & 0x00000000FF000000L) << 8 | 
                (value & 0x000000FF00000000L) >> 8 | 
                (value & 0x0000FF0000000000L) >> 24 | 
                (value & 0x00FF000000000000L) >> 40 |
                (value & 0x7F00000000000000L) >> 56;
        }

        public static float ReverseBytes_Float(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        public static double ReverseBytes_Double(double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }
    }
}

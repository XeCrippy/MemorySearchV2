using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorySearchV2.Helpers
{
    public static class ConversionHelper
    {
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
    }
}

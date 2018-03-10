using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chonla.ThaiEncoding {
    public static class Convert {
        private const byte UTF8_IDENTIFIER = 224;

        public static byte[] ToTIS620(string utf8String) {
            return utf8String
                    .ToCharArray()
                    .Select(utf8Char => ParseToTIS620Byte(utf8Char))
                    .ToArray();
        }

        public static byte[] ToUTF8(byte[] tis620Bytes) {
            List<byte> buffer = new List<byte>();
            byte safeAscii = 126;
            for (var i = 0; i < tis620Bytes.Length; i++) {
                if (tis620Bytes[i] > safeAscii) {
                    if (((0xa1 <= tis620Bytes[i]) && (tis620Bytes[i] <= 0xda))
                        || ((0xdf <= tis620Bytes[i]) && (tis620Bytes[i] <= 0xfb))) {
                            var utf8Char = 0x0e00 + tis620Bytes[i] - 0xa0;

                            byte utf8Byte1 = (byte)(0xe0 | (utf8Char >> 12));
                            buffer.Add(utf8Byte1);
                            byte utf8Byte2 = (byte)(0x80 | ((utf8Char >> 6) & 0x3f));
                            buffer.Add(utf8Byte2);
                            byte utf8Byte3 = (byte)(0x80 | (utf8Char & 0x3f));
                            buffer.Add(utf8Byte3);
                        }
                } else {
                    buffer.Add(tis620Bytes[i]);
                }
            }
            return buffer.ToArray();
        }

        #region Private methods

        private static byte ParseToTIS620Byte(char utf8Char)
        {
            var utf8CharBytes = Encoding.UTF8.GetBytes(utf8Char.ToString());
            if (HasToConvertToTIS620Byte(utf8CharBytes))
                return ParseToTIS620Byte(utf8CharBytes);

            return utf8CharBytes[0];
        }

        private static bool HasToConvertToTIS620Byte(byte[] utf8CharBytes)
        {
            return (utf8CharBytes.Length > 2
                    && utf8CharBytes[0] == UTF8_IDENTIFIER);
        }

        private static byte ParseToTIS620Byte(byte[] utf8CharBytes)
        {
            var tis620Char = (utf8CharBytes[2] & 0x3F);
            tis620Char |= ((utf8CharBytes[1] & 0x3F) << 6);
            tis620Char |= ((utf8CharBytes[0] & 0x0F) << 12);
            tis620Char -= (0x0E00 + 0xA0);

            var tis620Byte = (byte)tis620Char;
            tis620Byte += 0xA0;
            tis620Byte += 0xA0;

            return tis620Byte;
        }

        #endregion
    }
}
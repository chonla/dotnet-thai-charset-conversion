using System;
using System.Collections.Generic;
using System.Text;

public static class ThaiEncodingService {
    public static byte[] ToTIS620(string utf8String) {
        List<byte> buffer = new List<byte>();
        byte utf8Identifier = 224;
        for (var i = 0; i < utf8String.Length; i++) {
            string utf8Char = utf8String.Substring(i, 1);
            byte[] utf8CharBytes = Encoding.UTF8.GetBytes(utf8Char);
            if (utf8CharBytes.Length > 1 && utf8CharBytes[0] == utf8Identifier) {
                var tis620Char = (utf8CharBytes[2] & 0x3F);
                tis620Char |= ((utf8CharBytes[1] & 0x3F) << 6);
                tis620Char |= ((utf8CharBytes[0] & 0x0F) << 12);
                tis620Char -= (0x0E00 + 0xA0);
                byte tis620Byte = (byte)tis620Char;
                tis620Byte += 0xA0;
                tis620Byte += 0xA0;

                buffer.Add(tis620Byte);
            } else {
                buffer.Add(utf8CharBytes[0]);
            }
        }
        return buffer.ToArray();
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
}

namespace Chonla.ThaiEncoding
{
    public static class StringExtension
    {
        public static byte[] ToTIS620(this string utf8String)
        {
            return Convert.ToTIS620(utf8String);
        }
    }
}
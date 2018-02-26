using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // StreamReader sr = File.OpenText("utf8text.txt");
        byte[] tis620Bytes = File.ReadAllBytes("tis620text.txt");
        FileStream fs = File.OpenWrite("utf8out.txt");
        byte[] b = ThaiEncodingService.ToUTF8(tis620Bytes);
        fs.Write(b, 0, b.Length);
        fs.Close();
    }
}

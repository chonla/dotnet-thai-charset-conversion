# Thai Character Set Encoding Convert

## Example

```
    using Chonla.ThaiEncoding;

    // ...

    byte[] tis620Bytes = File.ReadAllBytes("tis620text.txt");
    FileStream fs = File.OpenWrite("utf8out.txt");
    byte[] b = Convert.ToUTF8(tis620Bytes);
    fs.Write(b, 0, b.Length);
    fs.Close();
```

## Author

[chonlasith](https://github.com/chonla)
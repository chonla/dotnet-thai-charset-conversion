using System;
using Xunit;
using Chonla.ThaiEncoding;

namespace Chonla.ThaiEncoding.Tests
{
    public class ThaiEncodingServiceTest
    {
        [Fact]
        public void TestNonThaiCharacterShouldBeConvertCorrectly()
        {
            byte[] result = Convert.ToTIS620("a");
            Assert.Single(result);
            Assert.Equal(new byte[]{ 0x61 }, result);
        }

        [Theory]
        [InlineData("ก", 0xa1)]
        [InlineData("ข", 0xa2)]
        [InlineData("ฃ", 0xa3)]
        [InlineData("ค", 0xa4)]
        [InlineData("ฅ", 0xa5)]
        [InlineData("ฆ", 0xa6)]
        [InlineData("ง", 0xa7)]
        [InlineData("จ", 0xa8)]
        [InlineData("ฉ", 0xa9)]
        [InlineData("ช", 0xaa)]
        [InlineData("ซ", 0xab)]
        [InlineData("ฌ", 0xac)]
        [InlineData("ญ", 0xad)]
        [InlineData("ฎ", 0xae)]
        [InlineData("ฏ", 0xaf)]
        [InlineData("ฐ", 0xb0)]
        [InlineData("ฑ", 0xb1)]
        [InlineData("ฒ", 0xb2)]
        [InlineData("ณ", 0xb3)]
        [InlineData("ด", 0xb4)]
        [InlineData("ต", 0xb5)]
        [InlineData("ถ", 0xb6)]
        [InlineData("ท", 0xb7)]
        [InlineData("ธ", 0xb8)]
        [InlineData("น", 0xb9)]
        [InlineData("บ", 0xba)]
        [InlineData("ป", 0xbb)]
        [InlineData("ผ", 0xbc)]
        [InlineData("ฝ", 0xbd)]
        [InlineData("พ", 0xbe)]
        [InlineData("ฟ", 0xbf)]
        [InlineData("ภ", 0xc0)]
        [InlineData("ม", 0xc1)]
        [InlineData("ย", 0xc2)]
        [InlineData("ร", 0xc3)]
        [InlineData("ฤ", 0xc4)]
        [InlineData("ล", 0xc5)]
        [InlineData("ฦ", 0xc6)]
        [InlineData("ว", 0xc7)]
        [InlineData("ศ", 0xc8)]
        [InlineData("ษ", 0xc9)]
        [InlineData("ส", 0xca)]
        [InlineData("ห", 0xcb)]
        [InlineData("ฬ", 0xcc)]
        [InlineData("อ", 0xcd)]
        [InlineData("ฮ", 0xce)]
        [InlineData("ฯ", 0xcf)]
        [InlineData("ะ", 0xd0)]
        [InlineData("ั", 0xd1)]
        [InlineData("า", 0xd2)]
        [InlineData("ำ", 0xd3)]
        [InlineData("ิ", 0xd4)]
        [InlineData("ี", 0xd5)]
        [InlineData("ึ", 0xd6)]
        [InlineData("ื", 0xd7)]
        [InlineData("ุ", 0xd8)]
        [InlineData("ู", 0xd9)]
        [InlineData("ฺ", 0xda)]
        [InlineData("฿", 0xdf)]
        [InlineData("เ", 0xe0)]
        [InlineData("แ", 0xe1)]
        [InlineData("โ", 0xe2)]
        [InlineData("ใ", 0xe3)]
        [InlineData("ไ", 0xe4)]
        [InlineData("ๆ", 0xe6)]
        [InlineData("็", 0xe7)]
        [InlineData("่", 0xe8)]
        [InlineData("้", 0xe9)]
        [InlineData("๊", 0xea)]
        [InlineData("๋", 0xeb)]
        [InlineData("์", 0xec)]
        [InlineData("ํ", 0xed)]
        [InlineData("๐", 0xf0)]
        [InlineData("๑", 0xf1)]
        [InlineData("๒", 0xf2)]
        [InlineData("๓", 0xf3)]
        [InlineData("๔", 0xf4)]
        [InlineData("๕", 0xf5)]
        [InlineData("๖", 0xf6)]
        [InlineData("๗", 0xf7)]
        [InlineData("๘", 0xf8)]
        [InlineData("๙", 0xf9)]
        public void TestThaiCharacterShouldBeConvertCorrectly(string input, byte expected) {
            byte[] result = Convert.ToTIS620(input);
            Assert.Single(result);
            Assert.Equal(new byte[]{ expected }, result);
        }
    }
}

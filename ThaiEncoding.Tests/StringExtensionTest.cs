using Xunit;
using ThaiEncoding.Tests;

namespace Chonla.ThaiEncoding.Tests
{
    public class StringExtensionTest : TestBase
    {
        [Fact]
        public void TestNonThaiCharacterShouldBeConvertCorrectly()
        {
            WhenAGivenCharacterIsConvertedToTIS620("a");

            ThenTheResultShouldBeOneByte();
            ThenTheResultShouldBeEqualTo(new byte[]{ 0x61 });
        }

        [Theory]
        [MemberData(nameof(DataSource.ThaiCharacters), MemberType = typeof(DataSource))]
        public void TestThaiCharacterShouldBeConvertCorrectly(string input, byte expected)
        {
            WhenAGivenCharacterIsConvertedToTIS620(input);

            ThenTheResultShouldBeOneByte();
            ThenTheResultShouldBeEqualTo(new byte[] { expected });
        }
    }
}

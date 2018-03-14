using Xunit;
using Chonla.ThaiEncoding;

namespace ThaiEncoding.Tests
{
    public abstract class TestBase
    {
        protected byte[] Result { get; private set; }

        protected void WhenAGivenCharacterIsConvertedToTIS620(string input) => Result = input.ToTIS620();

        protected void ThenTheResultShouldBeOneByte() => Assert.Single(Result);

        protected void ThenTheResultShouldBeEqualTo(byte[] expected) => Assert.Equal(expected, Result);
    }
}
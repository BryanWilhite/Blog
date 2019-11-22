using System;
using System.Threading.Tasks;
using Songhay.Extensions;
using Xunit;

namespace Songhay.Publications.Tests
{
    public class UriExtensionsTests
    {
        [Theory]
        [InlineData("https://t.co/2qFg6xmzBc")]
        [InlineData("http://tinyurl.com/htmlcss2019")]
        public async Task ToExpandedUriAsync_Test(string expandableUri)
        {
            var uri = new Uri(expandableUri);
            var expandedUri = await uri.ToExpandedUriAsync();
            Assert.NotEqual(uri, expandedUri);
        }
    }
}
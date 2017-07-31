using System;
using Xunit;

namespace TestLogin
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.NotEqual(2, 5);
        }

		[Theory]
		[InlineData("Does", "Does not appear in the string.")]
		[InlineData("Ting", "Ting appears once.")]
		[InlineData("Ting", "Ting appears twice with Ting.")]
		public void Test2(string searchWord, string inputString)
		{
            Assert.StartsWith(searchWord, inputString);
		}
    }
}

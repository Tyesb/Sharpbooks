using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpBooks.Services;

namespace SharpBooks.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExists()
        {
            //setup
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //assert
            Assert.IsNotNull(testSearch);
        }

        [TestMethod]
        public void testURICorrect()
        {
            //setup

        }
    }
}

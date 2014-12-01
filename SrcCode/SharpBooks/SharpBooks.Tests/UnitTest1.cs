using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpBooks.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpBooks.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExists()
        {
            //arrange
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //assert
            Assert.IsNotNull(testSearch);
        }

        [TestMethod]
        public void testValidAuthorName()
        {
            //arrange
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //act
            IEnumerable<Models.Book> result = testSearch.Search("Stephen King").Result;

            //assert
            Assert.IsNotNull(result);
            var CarrieResult = result.FirstOrDefault(n => n.Title.Equals("Carrie"));
            Assert.IsNotNull(CarrieResult);

        }

        [TestMethod]
        public void testInvalidAuthorName()
        {
            //arrange
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //act
            Guid guid =  Guid.NewGuid();
            String GuidString = guid.ToString(); 
            IEnumerable<Models.Book> result = testSearch.Search(GuidString).Result;

            //assert
            var GuidResult = result.Any(n => n.Title.Equals(GuidString));
            Assert.IsFalse(GuidResult);

        }
    }
}

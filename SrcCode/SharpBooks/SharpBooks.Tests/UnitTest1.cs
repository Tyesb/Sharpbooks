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
            IEnumerable<Models.Book> result = testSearch.GeneralSearch("Stephen King").Result;

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
            Guid guid = Guid.NewGuid();
            String GuidString = guid.ToString();
            IEnumerable<Models.Book> result = testSearch.GeneralSearch(GuidString).Result;

            //assert
            var GuidResult = result.Any(n => n.Title.Equals(GuidString));
            Assert.IsFalse(GuidResult);

        }

        [TestMethod]
        public void testTitleSearchReturnsNothing()
        {
            //arrange
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //act
            Guid guid = Guid.NewGuid();
            String GuidString = guid.ToString();
            IEnumerable<Models.Book> result = testSearch.TitleSearch(GuidString).Result;

            //assert
            var GuidResult = result.Any(n => n.Title.Equals(GuidString));
            Assert.IsFalse(GuidResult);

        }

        [TestMethod]
        public void testSearchById()
        {
            //arrange
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //act
            IEnumerable<Models.Book> result = testSearch.GeneralSearch("8_DfMSS9r9cC").Result;

            //assert
            Assert.IsNotNull(result);
            var CarrieResult = result.FirstOrDefault(n => n.Title.Equals("Diversity and Evolutionary Biology of Tropical Flowers"));
            Assert.IsNotNull(CarrieResult);

        }


        [TestMethod]
        public void testTitleSearchReturns()
        {
            //arrange
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //act
            IEnumerable<Models.Book> result = testSearch.TitleSearch("The Shining").Result;

            //assert
            Assert.IsNotNull(result);
            var book = result.FirstOrDefault(n => n.Title.Equals("The Shining"));
            Assert.IsNotNull(book);

        }

       

        [TestMethod]
        public void testISBNeSearchReturns()
        {
            //arrange
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //act
            IEnumerable<Models.Book> result = testSearch.ISBNSearch("1741147514").Result;

            //assert
            Assert.IsNotNull(result);
            var book = result.FirstOrDefault(n => n.Title.Equals("The Book of Everything"));
            Assert.IsNotNull(book);
            Assert.AreEqual("The Book of Everything", book.Title);


        }

        //https://www.acmi.net.au/media/12347/javascript_the_good_parts.pdf


        [TestMethod]
        public void searchReturnsNothing()
        {
            //arrange
            GoogleBookSearch testSearch = new GoogleBookSearch();

            //act
            Guid guid = Guid.NewGuid();
            String GuidString = guid.ToString();
            IEnumerable<Models.Book> result = testSearch.ISBNSearch(GuidString).Result;

            //assert
            var GuidResult = result.Any(n => n.Title.Equals(GuidString));
            Assert.IsFalse(GuidResult);

        }
    }
}

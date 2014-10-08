using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstroScraper;
using System.Diagnostics;

namespace AstroTests
{
    [TestClass]
    public class ScrapeTests
    {
        [TestMethod]
        public void GetAdvertTest()
        {
            Scraper scraper = new Scraper(81301);
            bool result = scraper.NewItemFound();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FindLatestItemTest()
        {
            Scraper scraper = new Scraper();
            int start = 75780;
            int last = scraper.FindLatestItem(start);
            Debug.Print(last.ToString());
            Assert.AreNotSame(start,last);
        }

    }
}

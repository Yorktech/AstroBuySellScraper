using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstroScraper;

namespace AstroTests
{
    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void SendEmailMessageTest()
        {
            IMessenger mess = new EmailHelper();
  
            mess.SendMessage("Hello this is a test email","steve@minster-it.com","","","");
        }
    }
}

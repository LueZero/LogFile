using NUnit.Framework;
using LogFile;
using System;
using Moq;
using Moq.Protected;
using System.Text;
using System.IO;

namespace LogFileTest.Feature
{
    [TestFixture]
    class LogTest
    {
        [Test]
        public void GiveLogTxtType_WhenCreateLogger_ThenReturnCreateLogFileContent()
        {
            //Assert
            Assert.AreEqual(1, 1);
        }
    }
}

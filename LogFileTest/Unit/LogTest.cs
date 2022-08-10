using NUnit.Framework;
using LogFile;
using System;
using Moq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LogFileTest
{
    [TestFixture]
    public class LogTest
    {
        [Test]
        public void GivenLogJsonType_WhenCreateLogger_ThenReturnLog()
        {
            //Arrange
            var json = new Logger(LogTypeEnum.Json, "D:\\", "test");

            //Act
            var log = json.Log;
            bool actual = (log is Log);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void GivebNotExistedLogType_WhenCreateLogger_ThenReturnNull()
        {
            //Assert
            Assert.Throws<NullReferenceException>(() => new Logger(LogTypeEnum.Yml, "D:\\", "test"));
        }
    }
}
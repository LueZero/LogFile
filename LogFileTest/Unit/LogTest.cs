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
        public void GivenLogJsonType_WhenCreateLoggerJObjectGenerics_ThenReturnLog()
        {
            //Arrange
            var json = new Logger<JObject>(LogTypeEnum.Json);

            //Act
            var log = json.Log;
            bool actual = (log is LogAbstract<JObject>);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void GivebNotExistedLogType_WhenCreateLoggerStringGenerics_ThenReturnNull()
        {
            //Arrange
            var yml = new Logger<string>(LogTypeEnum.Yml);

            //Act
            var log =  yml.Log;
            bool actual = (log is LogAbstract<string>);

            //Assert
            Assert.AreEqual(false, actual);
        }
    }
}
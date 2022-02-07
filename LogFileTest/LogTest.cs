using NUnit.Framework;
using LogFile;
using LogFile.Interfaces;
using System;

namespace LogFileTest
{
    public class LogTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LogCreateLogTest()
        {
            //Arrange
            var jsonLog = new Log("json");
            var actual = "{}";

            //Act
            jsonLog.saveLog("D:\\", "test", actual);

            //Assert
            Assert.That(actual, Is.EqualTo(jsonLog.getLogString()));
        }
    }
}
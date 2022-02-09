using NUnit.Framework;
using LogFile;
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
            var jsonLog = new Logger(LogTypeEnume.json);
            var actual = "{}";

            //Act
            jsonLog.createLog("D:\\", "test", actual);

            //Assert
            Assert.That(actual, Is.EqualTo(jsonLog.getLog()));
        }
    }
}
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
            var jsonLog = new Log(LogTypeEnume.json);
            var actual = "{}";

            //Act
            jsonLog.createLogFile("D:\\", "test", actual);

            //Assert
            Assert.That(actual, Is.EqualTo(jsonLog.getLogFile()));
        }
    }
}
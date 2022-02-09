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
            var jsonLog = new Logger(LogTypeEnume.json);
            var actual = "{}";
            jsonLog.path = "D:\\";
            jsonLog.fileName = "test";
            jsonLog.content = actual;
            //Act
            jsonLog.createLog();

            //Assert
            Assert.That(actual, Is.EqualTo(jsonLog.getLogString()));
        }
    }
}
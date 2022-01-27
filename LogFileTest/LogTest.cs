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
        public void TestOne()
        {
            //Arrange
            var jsonLog = new Log("json");
            var actual = "{}";

            //Act
            jsonLog.create("D:\\test.xml", actual);

            //Assert
            Assert.That(actual, Is.EqualTo(jsonLog.get()));
        }
    }
}
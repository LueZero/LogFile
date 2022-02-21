using NUnit.Framework;
using LogFile;
using System;
using Moq;
using System.Text;
using System.IO;

namespace LogFileTest
{
    [TestFixture]
    public class LogTest
    {
        [Test]
        public void GivenLogJsonType_WhenCeateLogClass_ThenReturnLogAbstract()
        {
            //Arrange
            Log log = new Log(LogTypeEnume.json);

            //Act
            LogAbstract logAbstract = log.logAbstract;
            bool actual = (logAbstract is LogAbstract);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void GivenLogXmlType_WhenCeateLogClass_ThenReturnLogAbstract()
        {
            //Arrange
            Log log = new Log(LogTypeEnume.xml);

            //Act
            LogAbstract logAbstract = log.logAbstract;
            bool actual = (logAbstract is LogAbstract);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void GivenLogTxtType_WhenCeateLogClass_ThenReturnLogAbstract()
        {
            //Arrange
            Log log = new Log(LogTypeEnume.txt);

            //Act
            LogAbstract logAbstract = log.logAbstract;
            bool actual = (logAbstract is LogAbstract);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void GivebNotExistedLogType_WhenCeateLogClass_ThenReturnNull()
        {
            //Arrange
            Log log = new Log(LogTypeEnume.yml);

            //Act
            LogAbstract logAbstract = log.logAbstract;
            bool actual = (logAbstract is LogAbstract);

            //Assert
            Assert.AreEqual(false, actual);
        }
    }
}
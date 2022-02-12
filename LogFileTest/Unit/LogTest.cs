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
        [SetUp]
        public void Setup()
        {
        }

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


        [Test]
        public void GivebCreateLogTxtType_WhenCeateLogClass_ThenReturnFileContent()
        {
            //Arrange
            Log log = new Log(LogTypeEnume.txt);
            string contetn = "hello";
            log.createLogFile("D:\\", "test", contetn);
            FileStream file = log.logAbstract.read("D:\\test.txt");

            //Act
            int len = (int)file.Length;
            byte[] b = new byte[len];
            int r = file.Read(b, 0, b.Length);
            string actual = System.Text.Encoding.UTF8.GetString(b);
           
            //Assert
            Assert.AreEqual(contetn, actual);
        }


        [Test]
        public void GivenCreateLog_WhenLogAbstract_ThenReturnLogContent()
        {
            //Arrange
            var mock = new Mock<LogAbstract>();
            string content = "{}";

            mock.Setup(m => m.create());
            mock.Setup(m => m.get()).Returns(content);

            //Act
            string actual = mock.Object.get();

            //Assert
            Assert.AreEqual(content, actual);
        }
    }
}
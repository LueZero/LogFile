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
            //Arrange
            string content = "he1lo";

            var mock = new Mock<Logger>(LogTypeEnum.Txt);

            mock.Setup(s => s.SetLogFileContent(content)).Callback((string content) => {
                mock.Object.Log.Content = content;
            });

            mock.Setup(s => s.CreateLogFile("D:\\", "test")).Callback((string path, string fileName) => {

                string fullFilePath = path + fileName + ".txt";

                using (FileStream fs = File.Create(fullFilePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(mock.Object.Log.Content);

                    fs.Write(info, 0, info.Length);
                }
            });

            mock.Setup(m => m.Log.Read("D:\\test.txt")).Returns((string fullFilePath) => {
                return File.OpenRead(fullFilePath);
            });

            //Act
            mock.Object.SetLogFileContent("he1lo");
            mock.Object.CreateLogFile("D:\\", "test");

            FileStream file = mock.Object.Log.Read("D:\\test.txt");

            int len = (int)file.Length;
            byte[] b = new byte[len];
            int r = file.Read(b, 0, b.Length);
            string actual = System.Text.Encoding.UTF8.GetString(b);

            //Assert
            Assert.AreEqual(content, actual);
        }
    }
}

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
        public void GiveLogTxtType_WhenCeateLogClass_ThenReturnFileContent()
        {
            //Arrange
            string contetn = "hello";

            var mock = new Mock<Log>(LogTypeEnume.Txt);

            mock.Setup(m => m.CreateLogFile("D:\\", "test", contetn)).Callback((string path, string fileName, string content) => {
                
                string fullFilePath = path + fileName + ".txt";

                using (FileStream fs = File.Create(fullFilePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(content.ToString());

                    fs.Write(info, 0, info.Length);
                }

            }).Verifiable();

            mock.Setup(m => m.LogAbstract.Read("D:\\test.txt")).Returns((string fullFilePath) => {

                return File.OpenRead(fullFilePath);

            });

            //Act
            mock.Object.CreateLogFile("D:\\", "test", contetn);

            FileStream file = mock.Object.LogAbstract.Read("D:\\test.txt");
            
            int len = (int)file.Length;
            byte[] b = new byte[len];
            int r = file.Read(b, 0, b.Length);
            string actual = System.Text.Encoding.UTF8.GetString(b);

            //Assert
            Assert.AreEqual(contetn, actual);
        }
    }
}

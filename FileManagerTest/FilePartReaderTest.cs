using System;
using System.IO;
using FileManager;
using NUnit.Framework;

namespace FileManagerTest
{
    [TestFixture]
    public class FilePartReaderTest
    {
        private FilePartReader _filePartReader;

        [SetUp]
        public void Setup()
        {
            this._filePartReader = new FilePartReader();
        }

        [Test]
        public void ThrowArgumentExceptionAtDefaultSetup()
        {
            Assert.Throws<ArgumentException>(() => _filePartReader.Read());
        }

        [Test]
        public void ThrowArgumentExceptionIfFromLineIsBiggerThanToLine()
        {
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 4;
            const int toLine = 1;
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup(filePath, fromLine, toLine));
        }

        [Test]
        public void ThrowArgumentExceptionIfFromLineIsLessThanOne()
        {
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 0;
            const int toLine = 4;
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup(filePath, fromLine, toLine));
        }

        [Test]
        public void ThrowArgumentExceptionIfFilePathIsEmpty()
        {
            const string filePath = "";
            const int fromLine = 1;
            const int toLine = 4;
            _filePartReader.Setup(filePath, fromLine, toLine);
            Assert.Throws<ArgumentException>(() => _filePartReader.Read());
        }

        [Test]
        public void ThrowFileNotFoundExceptionExceptionIfFilePathIsWrong()
        {
            const string filePath = "a";
            const int fromLine = 1;
            const int toLine = 4;
            _filePartReader.Setup(filePath, fromLine, toLine);
            Assert.Throws<FileNotFoundException>(() => _filePartReader.Read());
        }

        [Test]
        public void GetFileContentWhenReadFromFile()
        {
            const string expectedContent = "first line of text\r\n" +
                                           "second line add remove edit\r\n" +
                                           "third line some words extra\r\n" +
                                           "fourth";
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 1;
            const int toLine = 4;
            _filePartReader.Setup(filePath, fromLine, toLine);
            string actual = _filePartReader.Read();
            Assert.AreEqual(expectedContent, actual);
        }
    }
}
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
            string filePath = @"F:\C#\PROJECTS\FilePartReader";
            int fromLine = 4;
            int toLine = 1;
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup(filePath, fromLine, toLine));
        }

        [Test]
        public void ThrowArgumentExceptionIfFromLineIsLessThanOne()
        {
            string filePath = @"F:\C#\PROJECTS\FilePartReader";
            int fromLine = 0;
            int toLine = 4;
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup(filePath, fromLine, toLine));
        }
    }
}
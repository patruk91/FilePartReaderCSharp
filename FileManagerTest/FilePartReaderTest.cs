using System;
using System.IO;
using FileManager;
using Moq;
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

        [Test]
        public void GetTwoLinesWhenReadFromFile()
        {
            const string expectedContent = "first line of text second line add remove edit";
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 1;
            const int toLine = 2;
            _filePartReader.Setup(filePath, fromLine, toLine);
            string actual = _filePartReader.ReadLines();
            Assert.AreEqual(expectedContent, actual);
        }

        [Test]
        public void GetOneLineIfFromLineAndToLineAreEqualToOneWhenReadFromFile()
        {
            const string expectedContent = "first line of text";
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 1;
            const int toLine = 1;
            _filePartReader.Setup(filePath, fromLine, toLine);
            string actual = _filePartReader.ReadLines();
            Assert.AreEqual(expectedContent, actual);
        }

        [Test]
        public void GetContentIfToLineHaveMoreLineThenFileHaveWhenReadFromFile()
        {
            const string expectedContent = "first line of text " +
                                           "second line add remove edit " +
                                           "third line some words extra " +
                                           "fourth";
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 1;
            const int toLine = 100;
            _filePartReader.Setup(filePath, fromLine, toLine);
            string actual = _filePartReader.ReadLines();
            Assert.AreEqual(expectedContent, actual);
        }

        [Test]
        public void GetContentIfFileIsEmptyWhenReadFromFile()
        {
            const string expectedContent = "";
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\emptyTest.txt";
            const int fromLine = 1;
            const int toLine = 5;
            _filePartReader.Setup(filePath, fromLine, toLine);
            string actual = _filePartReader.ReadLines();
            Assert.AreEqual(expectedContent, actual);
        }

        [Test]
        public void InvokeReadMethodBeforeReadLinesMethodIsExecuted()
        {
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 1;
            const int toLine = 5;

            Mock<FilePartReader> filePartReaderMock = new Mock<FilePartReader> {CallBase = true};
            filePartReaderMock.Object.Setup(filePath, fromLine, toLine);
            filePartReaderMock.Object.ReadLines();
            filePartReaderMock.CallBase = false;
            filePartReaderMock.Verify(x => x.Read(), Times.Once);

        }
    }
}
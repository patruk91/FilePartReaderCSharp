using System;
using System.Collections.Generic;
using System.IO;
using FileManager;
using Moq;
using NUnit.Framework;

namespace FileManagerTest
{
    [TestFixture]
    public class FileWordAnalyzerTest
    {
        private Mock<FilePartReader> _filePartReaderMock;
        private FileWordAnalyzer _fileWordAnalyzer;
        [SetUp]
        public void Setup()
        {
            this._filePartReaderMock = new Mock<FilePartReader>();
            this._fileWordAnalyzer = new FileWordAnalyzer(_filePartReaderMock.Object);
        }

        [Test]
        public void SortWordAlphabeticallyFromString()
        {
            List<string> expected =  new List<string> { "alpha", "beta", "gamma", "theta", "zeta" };
            _filePartReaderMock.Setup(mock => mock.ReadLines()).Returns("gamma zeta beta theta alpha");

            List<string> actual = _fileWordAnalyzer.GetWordsOrderedAlphabetically();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfListIsEmptyFromEmptyString()
        {
            List<string> expected = new List<string> {""};
            List<string> actual = new List<string>();
            _filePartReaderMock.Setup(mock => mock.ReadLines()).Returns("");

            actual = _fileWordAnalyzer.GetWordsOrderedAlphabetically();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VerifyIsReadLinesMethodIsInvokedWhenExecuteGetWordsOrderedAlphabetically()
        {
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 1;
            const int toLine = 4;
            _filePartReaderMock.CallBase = true;
            _filePartReaderMock.Object.Setup(filePath, fromLine, toLine);
            Mock<FileWordAnalyzer> fileWordAnalyzerMock = new Mock<FileWordAnalyzer>(_filePartReaderMock.Object);

            fileWordAnalyzerMock.Object.GetWordsOrderedAlphabetically();
            _filePartReaderMock.CallBase = false;

            _filePartReaderMock.Verify(x => x.ReadLines(), Times.Once);
        }

        [Test]
        public void GetWordsContainingSubstringFromString()
        {
            List<string> expected = new List<string> { "zeta", "beta", "theta" };
            _filePartReaderMock.Setup(mock => mock.ReadLines()).Returns("gamma zeta beta theta alpha");

            List<string> actual = _fileWordAnalyzer.GetWordsContainingSubstring("eta");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetWordsContainingSubstringFromStringWithDifferentCases()
        {
            List<string> expected = new List<string> { "Zeta", "beta", "Theta" };
            _filePartReaderMock.Setup(mock => mock.ReadLines()).Returns("gamma Zeta beta Theta alpha");

            List<string> actual = _fileWordAnalyzer.GetWordsContainingSubstring("eta");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VerifyIsReadLinesMethodIsInvokedWhenExecuteGetWordsContainingSubstring()
        {
            const string filePath = @"F:\C#\PROJECTS\FilePartReader\test.txt";
            const int fromLine = 1;
            const int toLine = 5;
            _filePartReaderMock.CallBase = true;
            _filePartReaderMock.Object.Setup(filePath, fromLine, toLine);
            Mock<FileWordAnalyzer> fileWordAnalyzerMock = new Mock<FileWordAnalyzer>(_filePartReaderMock.Object);

            fileWordAnalyzerMock.Object.GetWordsContainingSubstring("et");
            _filePartReaderMock.CallBase = false;

            _filePartReaderMock.Verify(x => x.ReadLines(), Times.Once);

        }
    }
}
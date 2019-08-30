using System;
using System.Collections.Generic;
using System.Linq;

namespace FileManager
{
    public class FileWordAnalyzer
    {
        private FilePartReader _filePartReader;

        public FileWordAnalyzer(FilePartReader filePartReader)
        {
            _filePartReader = filePartReader;
        }

        public string[] GetWords()
        {
            string content = _filePartReader.ReadLines();
            return content.Split(separator: " ");
        }
    }
}
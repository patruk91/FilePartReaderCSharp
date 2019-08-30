using System;
using System.Collections.Generic;
using System.Linq;

namespace FileManager
{
    public class FileWordAnalyzer
    {
        private readonly FilePartReader _filePartReader;

        public FileWordAnalyzer(FilePartReader filePartReader)
        {
            _filePartReader = filePartReader;
        }

        public List<string> GetWordsOrderedAlphabetically()
        {
            string[] words = GetWords();
            Array.Sort(words);
            return words.ToList();
        }

        public List<string> GetWordsContainingSubstring(string substring)
        {
            string[] words = GetWords();
            return words.Where(word => word.Contains(substring)).ToList();
        }

        public string[] GetWords()
        {
            string content = _filePartReader.ReadLines();
            return content.Split(separator: " ");
        }
    }
}
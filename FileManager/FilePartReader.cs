﻿using System;

namespace FileManager
{
    public class FilePartReader
    {
        private string _filePath;
        private int? _fromLine;
        private int? _toLine;

        public FilePartReader()
        {
            _filePath = "";
            _fromLine = null;
            _toLine = null;
        }

        public void Setup(string filePath, int fromLine, int toLine)
        {
            if (toLine < fromLine) throw new ArgumentException(
                message: "Invalid argument: fromLine is bigger than toLine");
            if (fromLine < 1) throw new ArgumentException(
                message: "Invalid argument: fromLine is less than one");
            this._filePath = filePath;
            this._fromLine = fromLine;
            this._toLine = toLine;
        }
    }
}
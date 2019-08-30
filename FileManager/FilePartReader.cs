using System;
using System.IO;
using System.Text;

namespace FileManager
{
    public class FilePartReader
    {
        private string _filePath;
        private int _fromLine;
        private int _toLine;

        public FilePartReader()
        {
            _filePath = string.Empty;
            _fromLine = -1;
            _toLine = -1;
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

        public virtual string Read()
        {
            return File.ReadAllText(Path.GetFullPath(_filePath));
        }

        public string ReadLines()
        {
            string content = Read();
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(content))
            {
                string[] lines = content.Split(separator: "\n");
                _toLine = Math.Min(lines.Length, _toLine);

                int startLine = _fromLine - 1;
                for (int i = startLine; i < _toLine; i++)
                {
                    sb.Append(lines[i].Trim()).Append(" ");
                }
            }
            return sb.ToString().Trim();
        }
    }
}
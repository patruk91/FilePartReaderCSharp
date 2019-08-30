using System;
using System.Linq;

namespace FileHelper
{
    public static class FileLibrary
    {
        public static string ReverseWord(this string str)
        {
            return new string(str.ToCharArray().Reverse().ToArray());
        }
    }
}

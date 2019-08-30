using System;
using System.Linq;

namespace FileHelper
{
    public static class FileLibrary
    {
        public static string Reverse(this string str)
        {
            return str.ToCharArray().Reverse().ToString();
        }
    }
}

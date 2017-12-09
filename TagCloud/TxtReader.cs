using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagCloud
{
    class TxtReader : IFormatReader
    {
        private string formatFile = ".txt";

        public List<string> GetFileData(string fileName)
        {
            var wordsFromFile = new List<string>();
            if (!fileName.EndsWith(formatFile))
                throw new Exception("Incorrect format file");

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine().Split(' ').Where(word => !string.IsNullOrWhiteSpace(word));
                    wordsFromFile = wordsFromFile.Concat(line).ToList();
                }
            }

            return wordsFromFile;
        }
    }
}

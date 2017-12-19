using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace TagCloud
{
    public class TxtReader : IFormatReader
    {
        private const string formatFile = ".txt";

        [AssertionMethod]
        private void CheckCorrectFile(string fileName)
        {
            if (!fileName.EndsWith(formatFile))
                throw new FormatException($"Incorrect file format {fileName}");
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"Not found file: {fileName}");
            }
        }

        public List<Word> GetFileData(string fileName)
        {
            CheckCorrectFile(fileName);
            return  File.ReadLines(fileName)
                .SelectMany(l => l.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries))
                .Select(w => w.TrimEnd(',', '.', '?', '!'))
                .GroupBy(w => w)
                .Select(g => new Word
                {
                    Text = g.Key,
                    Quantity = g.Count()
                })
                .ToList();
        }
    }
}

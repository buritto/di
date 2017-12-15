using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagCloud
{
    public class TxtReader : IFormatReader
    {
        private string formatFile = ".txt";

        public List<Word> GetFileData(string fileName)
        {
            if (!fileName.EndsWith(formatFile))
                throw new FormatException("Incorrect format file");

            return  File.ReadLines(fileName)
                .SelectMany(l => l.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries))
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

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
        private string CheckCorrectFile(string fileName)
        {
            if (!fileName.EndsWith(formatFile))
               return $"Incorrect file format {fileName}";

            if (!File.Exists(fileName))
                return  $"Not found file: {fileName}";
            return null;
        }

        public Result<List<Word>> GetFileData(string fileName)
        {
            CheckCorrectFile(fileName);
            return  Result.Of(() => File.ReadLines(fileName)
                .SelectMany(l => l.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries))
                .Select(w => w.TrimEnd(',', '.', '?', '!'))
                .GroupBy(w => w)
                .Select(g => new Word
                {
                    Text = g.Key,
                    Quantity = g.Count()
                })
                .ToList(), CheckCorrectFile(fileName));
        }
    }
}

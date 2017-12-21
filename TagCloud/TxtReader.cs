using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagCloud
{
    public class TxtReader : IFormatReader
    {
        private const string formatFile = ".txt";

        private Result<IEnumerable<string>> RemoveSpaces(IEnumerable<string> data)
        {
            return data.SelectMany(words => words.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)).AsResult();
        }

        private Result<IEnumerable<string>> RemovePunctuationMarks(IEnumerable<string> data)
        {
            return data.Select(w => w.TrimEnd(',', '.', '?', '!')).AsResult();
        }

        private Result<IEnumerable<IGrouping<string, string>>> Group(IEnumerable<string> data)
        {
            return data.GroupBy(w => w).AsResult();
        }

        private Result<List<Word>> CreateListPairs(IEnumerable<IGrouping<string, string>> data)
        {
            return data.Select(g => new Word
            {
                Text = g.Key,
                Quantity = g.Count()
            }).ToList().AsResult();
        }

        private Result<IEnumerable<string>> ReadDataFromFile(string fileName)
        {
            if (!fileName.EndsWith(formatFile))
                Result.Fail<IEnumerable<string>>($"Incorrect file format {fileName}");

            if (!File.Exists(fileName))
                Result.Fail<IEnumerable<string>>($"Not found file: {fileName}");

            return File.ReadAllLines(fileName).AsEnumerable().AsResult();
        }

        public Result<List<Word>> GetFileData(string fileName)
        {
            return ReadDataFromFile(fileName)
                .Then(RemoveSpaces)
                .Then(RemovePunctuationMarks)
                .Then(Group)
                .Then(CreateListPairs);
        }
    }
}

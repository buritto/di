using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagCloud
{
    public class TxtReader : IFormatReader
    {
        private string formatFile = ".txt";

        public List<Tuple<string, int>> GetFileData(string fileName)
        {
            var wordsFromFile = new List<string>();
            if (!fileName.EndsWith(formatFile))
                throw new FormatException("Incorrect format file");

            // todo: use single linq query /aa
            var result = File.ReadLines(fileName)
                .SelectMany(l => l.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries))
                .GroupBy(w => w)
                .Select(g => new Word
                {
                    Text = g.Key,
                    Quantity = g.Count()
                })
                .ToList();


            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine().Split(' ').Where(word => !string.IsNullOrWhiteSpace(word));
                    wordsFromFile = wordsFromFile.Concat(line).ToList();
                }
            }
            var differentWords = wordsFromFile.Distinct().ToList();
            var countWordsInText = GetCountWordsInText(differentWords, wordsFromFile);
            return GetTuples(differentWords, countWordsInText);
        }

        private List<Tuple<string, int>> GetTuples(List<string> differentWords, List<int> countWordsInText)
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>(differentWords.Count);
            for (int i = 0; i < differentWords.Count; i++)
            {
                result.Add(new Tuple<string, int>(differentWords[i], countWordsInText[i]));
            }
            return result;
        }

        private List<int> GetCountWordsInText(List<string> differentWords, List<string> wordsFromFile)
        {
            var result = new List<int>(differentWords.Count());
            foreach (var word in differentWords)
            {
                result.Add(wordsFromFile.Count(w => w == word));
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagCloud
{
    class ArchitectDecreasingSpiral : IArchitect
    {
        public List<Size> GetSizeWords(List<Tuple<string, int>> wordsAndCounts, int widthWindow, int heightWindow)
        {
            var countWords = wordsAndCounts.Count; 
            var countAllWords = wordsAndCounts.Sum(tuple => tuple.Item2); // ask: why this is requeired? /aa
            return wordsAndCounts.Select(tuple => new Size(
                GetSide(tuple.Item2, countAllWords, widthWindow, countWords),
                GetSide(tuple.Item2, countAllWords, heightWindow, countWords, tuple.Item1.Length))).ToList();
        }

        private int GetSide(double countWord, double countAllWords, double sideWindow, double countDifferentWords, int wordLength = 1)
        {
            return (int)(countWord * sideWindow / (countDifferentWords));
        }
    }
}

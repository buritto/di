using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    class ArchitectDecreasingSpiral : IArchitect
    {
        public List<Size> GetSizeWords(List<Tuple<string, int>> wordsAndCounts, int widthWindow, int heightWindow)
        {
            var sizes = new List<Size>(wordsAndCounts.Count);
            var countWords = wordsAndCounts.Count; 
            var countAllWords = wordsAndCounts.Sum(tuple => tuple.Item2);
            return wordsAndCounts.Select(tuple => new Size(
                GetSide(tuple.Item2, countAllWords, widthWindow, countWords),
                GetSide(tuple.Item2, countAllWords, heightWindow, countWords))).ToList();
        }

        private int GetSide(int countWord, int countAllWords, int widthWindow, int countDifferentWords)
        {
            return (countWord / countAllWords) * (widthWindow / countDifferentWords);
        }
    }
}

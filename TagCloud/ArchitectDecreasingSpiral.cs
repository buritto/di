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
            var countWords = wordsAndCounts.Count; 
            var countAllWords = wordsAndCounts.Sum(tuple => tuple.Item2);
            return wordsAndCounts.Select(tuple => new Size(
                GetSide(tuple.Item2, countAllWords, widthWindow, countWords),
                GetSide(tuple.Item2, countAllWords, heightWindow, countWords))).ToList();
        }

        private int GetSide(double countWord, double countAllWords, double sideWindow, double countDifferentWords)
        {
            var res = (int)((countWord / countAllWords) * (sideWindow / countDifferentWords));
            return (int)((countWord / countAllWords) * 50 * (sideWindow / countDifferentWords));
        }
    }
}

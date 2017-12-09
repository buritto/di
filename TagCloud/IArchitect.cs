using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    interface IArchitect
    {
        List<Size> GetSizeWords(List<Tuple<string, int>> wordsAndCounts, int widthWindow, int heightWindow);
    }
}

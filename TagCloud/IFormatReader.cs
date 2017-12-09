using System;
using System.Collections.Generic;

namespace TagCloud
{
    interface IFormatReader
    {
        List<Tuple<string, int>> GetFileData(string fileName);
    }
}

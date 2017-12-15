using System;
using System.Collections.Generic;

namespace TagCloud
{
    public interface IFormatReader
    {
        List<Tuple<string, int>> GetFileData(string fileName); // todo: use a Word class /aa
    }
}

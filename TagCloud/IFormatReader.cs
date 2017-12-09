using System.Collections.Generic;

namespace TagCloud
{
    interface IFormatReader
    {
        List<string> GetFileData(string fileName);
    }
}

using System.Collections.Generic;

namespace TagCloud
{    /// <summary>
     /// Reads text from files of different formats. Returns a list of words in the file and their number
     /// </summary>
    public interface IFormatReader
    {
        List<Word> GetFileData(string fileName); 
    }
}

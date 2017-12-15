namespace TagCloud
{
    /// <summary>
    /// Check if word match filtering rules
    /// </summary>
    public interface IWordFilter
    {
        IWordFilter AddBoringWord(string word);
        IWordFilter SetMinCountSymbolInWord(int lenght);
        bool ValidWord(string word);
    }
}


namespace TagCloud
{
    /// <summary>
    /// Check if word match filtering rules
    /// </summary>
    public interface IWordFilter
    {
        int MinLenght { get; }
        IWordFilter AddBoringWord(string word);
        IWordFilter SetMinCountSymbolInWord(int lenght);
        bool IsWordValid(string word);
    }
}


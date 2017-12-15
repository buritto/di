using System.Collections.Generic;

namespace TagCloud
{
    public class ContentConfigurator : IWordFilter
    {
        public HashSet<string> BoringWords { get; private set; }
        public int MinLenght { get; private set; }

        public ContentConfigurator()
            : this(new HashSet<string>())
        {
        }

        public ContentConfigurator(HashSet<string> boringWords)
        {
            this.BoringWords = boringWords;
        }

        public IWordFilter AddBoringWord(string word)
        {
            BoringWords.Add(word);
            return this;
        }

        public IWordFilter SetMinCountSymbolInWord(int lenght)
        {
            MinLenght = lenght;
            return this;
        }

        public bool IsWordValid(string word)
        {
            return word.Length >= MinLenght && !BoringWords.Contains(word);
        }
    }
}

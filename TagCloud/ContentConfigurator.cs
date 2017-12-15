using System.Collections.Generic;

namespace TagCloud
{
    public class ContentConfigurator : IWordFilter
    {
        private readonly HashSet<string> boringWords;
        private int minLenght;

        public ContentConfigurator()
            : this(new HashSet<string>())
        {
        }

        public ContentConfigurator(HashSet<string> boringWords)
        {
            this.boringWords = boringWords;
        }

        public IWordFilter AddBoringWord(string word)
        {
            boringWords.Add(word);
            return this;
        }

        public IWordFilter SetMinCountSymbolInWord(int lenght)
        {
            minLenght = lenght;
            return this;
        }

        public bool IsWordValid(string word)
        {
            return word.Length >= minLenght && !boringWords.Contains(word);
        }
    }
}

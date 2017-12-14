﻿using System.Collections.Generic;

namespace TagCloud
{
    class ContentConfigurator : IEditor
    {
        private readonly HashSet<string> boringWords;
        private int minLenght;

        public ContentConfigurator()
        {
            boringWords = new HashSet<string>();
        }

        public ContentConfigurator(HashSet<string> boringWords)
        {
            this.boringWords = boringWords;
        }

        public ContentConfigurator AddBoringWord(string word)
        {
            boringWords.Add(word);
            return this;
        }


        public ContentConfigurator SetMinCountSymbolInWord(int lenght)
        {
            minLenght = lenght;
            return this;
        }

        public bool ValidWord(string word)
        {
            return !boringWords.Contains(word) && word.Length >= minLenght;
        }

    }
}

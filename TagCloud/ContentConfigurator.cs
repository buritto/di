using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    class ContentConfigurator
    {
        private readonly HashSet<string> boringWords;

        public ContentConfigurator(HashSet<string> boringWords)
        {
            this.boringWords = boringWords;
        }

        public ContentConfigurator AddBoringWord(string word)
        {
            boringWords.Add(word);
            return this;
        }
    }
}

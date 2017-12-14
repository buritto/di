namespace TagCloud
{
    interface IEditor
    {
        ContentConfigurator AddBoringWord(string word);
        ContentConfigurator SetMinCountSymbolInWord(int lenght);
        bool ValidWord(string word);
    }
}


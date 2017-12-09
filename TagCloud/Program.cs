namespace TagCloud
{
    class Program
    {
        static void Main(string[] args)
        {
            var txtr = new TxtReader();
            var cf = new ContentConfigurator().SetMinCountSymbolInWord(3);
            var pc = new PictureConfigurator(1200, 900);
            var a = new ArchitectDecreasingSpiral();
            var tg = new TagCloud(txtr, cf, pc, a);
            tg.PaintTagCloud("Text.txt", "res.png");
        }
    }
}

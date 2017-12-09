using System.Drawing.Imaging;

namespace TagCloud
{
    class Program
    {
        static void Main(string[] args)
        {
            var txtr = new TxtReader();
            var cf = new ContentConfigurator();
            var pc = new PictureConfigurator(1200, 900, ImageFormat.Png);
            var a = new ArchitectDecreasingSpiral();
            var tg = new TagCloud(txtr, cf, pc, a);
            tg.PaintTagCloud("Text.txt", "res.png");
        }
    }
}

using System.Drawing;

namespace TagCloud
{
    class Program
    {
        static void Main(string[] args)
        {
            var readerFromTxtFile = new TxtReader();
            var simpleConyentConfig = new ContentConfigurator().SetMinCountSymbolInWord(3);
            var simplePictureConfig = new PictureConfigurator(1200, 900);
            var spiralBuilder = new SpiralBuilder(new Point(simplePictureConfig.Width / 2, simplePictureConfig.Height / 2),
                simplePictureConfig.Width, simplePictureConfig.Height);
            var tg = new TagCloud(readerFromTxtFile, simpleConyentConfig, simplePictureConfig, spiralBuilder);
            tg.PaintTagCloud("C:\\data\\Text.txt", "C:\\data\\res.png");
        }
    }
}

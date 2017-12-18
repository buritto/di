using System;
using System.Drawing;
using Autofac;
using DocoptNet;

namespace TagCloud
{
    public static class Program
    {
        private static void StartTagCloud(int width, int height, int count,
            Color color, float maxSizeWord, FontStyle style, string textFileName, string fileNameWithPicture)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TxtReader>().As<IFormatReader>();
            builder.Register(c =>
            {
                IWordFilter config = new ContentConfigurator();
                config = config.SetMinCountSymbolInWord(count);
                return (ContentConfigurator)config;
            }).As<IWordFilter>();
            builder.Register(c => new PictureConfigurator(width, height, color, maxSizeWord, style)).As<IPainter>();
            builder.Register(c => new SpiralBuilder(new Point(width / 2, height / 2), width, height))
                .As<ITagCloudBuilder>();
            builder.RegisterType<TagCloud>();
            var container = builder.Build();
            using (container.BeginLifetimeScope())
            {
                var component = container.Resolve<TagCloud>();
                component.PaintTagCloud(textFileName, fileNameWithPicture);
            }
        }

        private const string usage = @" Tag Cloud

        Usage:
        TagCloud.exe [--width WIDTH] [--height HEIGHT] [--count COUNT] [--color COLOR] [--style STYLE] [--text TEXT] [--pict PICTURE] [--msize MAX]
        TagCloud.exe (-h|--help)

        Options:
        -h --help           Show this screen.
        --width WIDTH       Width window.[default: 800]
        --height HEIGHT     Height window.[default: 600]
        --count COUNT       Minimum number of characters allowed.[default: 3]
        --msize MAX         The maximum word size in the cloud.[default: 100]
        --color COLOR       Color text.[default: Red]
        --style STYLE       Font Style.[default: FontStyle.Regular]
        --text TEXT         File name\path is have some text.[default: input.txt]
        --pict PICTURE      File name\path where save picture.[default: output.png]
    ";

        static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, version: "Tag Cloud 0.1", exit: true);
            try
            {
                var width = int.Parse(arguments["--width"].Value.ToString());
                var height = int.Parse(arguments["--height"].Value.ToString());
                var count = int.Parse(arguments["--count"].Value.ToString());
                var maxSizeWord = float.Parse(arguments["--msize"].Value.ToString());
                var color = (Color) new ColorConverter().ConvertFromString(arguments["--color"].ToString());
                var fontStyle = ((Font) new FontConverter().ConvertFromString(arguments["--style"].ToString())).Style;
                var textFileName = arguments["--text"].Value.ToString();
                var fileNameWithPicture = arguments["--pict"].ToString();
                StartTagCloud(width, height, count, color, maxSizeWord, fontStyle, textFileName, fileNameWithPicture);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }
    }
}

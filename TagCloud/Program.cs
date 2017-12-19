using System;
using System.Drawing;
using Autofac;
using DocoptNet;

namespace TagCloud
{
    public static class Program
    {
        private static void StartTagCloud(Result<int> width, Result<int> height, Result<int> count,
            Result<Color> color, Result<float> maxSizeWord, Result<FontStyle> style,
            Result<string> textFileName, Result<string> fileNameWithPicture)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TxtReader>().As<IFormatReader>();
            builder.Register(c =>
            {
                IWordFilter config = new ContentConfigurator();
                config = config.SetMinCountSymbolInWord(count.TryGetValue());
                return (ContentConfigurator)config;
            }).As<IWordFilter>();
            builder.Register(c => new PictureConfigurator(width, height, color, maxSizeWord.TryGetValue(), style.TryGetValue())).As<IPainter>();
            builder.Register(c => new SpiralBuilder(new Point(width.TryGetValue() / 2, height.TryGetValue() / 2), width.TryGetValue(), height.TryGetValue()))
                .As<ITagCloudBuilder>();
            builder.RegisterType<TagCloud>();
            var container = builder.Build();
            using (container.BeginLifetimeScope())
            {
                var component = container.Resolve<TagCloud>();
                component.PaintTagCloud(textFileName.TryGetValue(), fileNameWithPicture.TryGetValue());
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
            try
            {
                var arguments = new Docopt().Apply(usage, args, version: "Tag Cloud 0.1", exit: true);

                var width = Result.Of(() => int.Parse(arguments["--width"].Value.ToString()), "Incorrect width");
                var height = Result.Of(() => int.Parse(arguments["--height"].Value.ToString()), "Incorrect height");
                var count = Result.Of(() => int.Parse(arguments["--count"].Value.ToString()), "Incorrect count");
                var maxSizeWord = Result.Of(() => float.Parse(arguments["--msize"].Value.ToString()),
                    "Incorrect max size word");
                var color = Result.Of(() =>
                    (Color) new ColorConverter().ConvertFromString(arguments["--color"].ToString()), "Incorrect color");
                var fontStyle = Result.Of(() =>
                        ((Font) new FontConverter().ConvertFromString(arguments["--style"].ToString())).Style,
                    "Incorrect font");
                var textFileName = Result.Of(() => arguments["--text"].Value.ToString());
                var fileNameWithPicture = Result.Of(() => arguments["--pict"].ToString());
                StartTagCloud(width, height, count, color, maxSizeWord, fontStyle, textFileName,fileNameWithPicture);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

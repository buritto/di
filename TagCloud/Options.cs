using System.Drawing;
using DocoptNet;

namespace TagCloud
{
    internal class Options
    {
        public int Width { get; }
        public int Height { get; }
        public int Count { get; }
        public float MaxSizeWord { get; }
        public Color Color { get; }
        public FontStyle FontStyle { get; }
        public string TextFileName { get; }
        public string FileNameWithPicture { get; }
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

        public Options(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, version: "Tag Cloud 0.1", exit: true);
       
            Width = int.Parse(arguments["--width"].Value.ToString());
            Height = int.Parse(arguments["--height"].Value.ToString());
            Count = int.Parse(arguments["--count"].Value.ToString());
            MaxSizeWord = float.Parse(arguments["--msize"].Value.ToString());
            Color = (Color)new ColorConverter().ConvertFromString(arguments["--color"].ToString());
            FontStyle = ((Font)new FontConverter().ConvertFromString(arguments["--style"].ToString())).Style;
            TextFileName = arguments["--text"].Value.ToString();
            FileNameWithPicture = arguments["--pict"].ToString();
        }
    }
}

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace TagCloud
{
    class TagCloud
    {
        private PictureConfigurator pictureConfigurator;
        private ContentConfigurator contentConfigurator;
        private IFormatReader reader;
        private IArchitect architect;
        private CircularCloudLayouter layout;

        public TagCloud(IFormatReader reader, ContentConfigurator contentConfigurator,
            PictureConfigurator pictureConfigurator, IArchitect architect)
        {
            this.reader = reader;
            this.contentConfigurator = contentConfigurator;
            this.pictureConfigurator = pictureConfigurator;
            this.architect = architect;
            layout = new CircularCloudLayouter(
                new Point(pictureConfigurator.Width / 2, pictureConfigurator.Height /2),
                pictureConfigurator.Width, pictureConfigurator.Height);
        }

        public void PaintTagCloud(string fileTestName, string pictureResultName)
        {
            var words = reader.GetFileData(fileTestName);
            words.Sort((t1, t2) => t1.Item2.CompareTo(t2.Item2));
            words = words.Where(tuple => contentConfigurator.ValidWord(tuple.Item1)).ToList();
            var sizeReactangleForWords =
                architect.GetSizeWords(words, pictureConfigurator.Width, pictureConfigurator.Height);
            var rectangles = new List<Rectangle>();
            foreach (var size in sizeReactangleForWords)
            {
                rectangles.Add(layout.PutNextRectangle(size));
            }
            var allWords = words.Select(tuple => tuple.Item1).ToList();

            var picture = new Bitmap(pictureConfigurator.Width, pictureConfigurator.Height);
            using (Graphics g = Graphics.FromImage(picture))
            {
                for (int i = 0; i < allWords.Count; i++)
                {
                    var word = allWords[i];
                    var colorForWord = pictureConfigurator.Painter.GetColorWord(word, sizeReactangleForWords[i]);
                    var fontForWord = pictureConfigurator.Painter.GetFontWord(word, sizeReactangleForWords[i]);
                    g.DrawString(
                        word,
                        fontForWord,
                        new SolidBrush(colorForWord), 
                        rectangles[i]
                        );
                }
                picture.Save(pictureResultName);
            }

        }
    }
}

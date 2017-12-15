using System;
using System.Drawing;
using System.Linq;

namespace TagCloud
{
    //[UsedImplicitly]
    public class TagCloud
    {
        private readonly IPainter pictureConfigurator;
        private readonly IWordFilter contentConfigurator;
        private readonly IFormatReader reader;
        private readonly ITagCloudBuilder builder;

        public TagCloud(IFormatReader reader, IWordFilter contentConfigurator,
            IPainter pictureConfigurator, ITagCloudBuilder builder)
        {
            this.reader = reader;
            this.contentConfigurator = contentConfigurator;
            this.pictureConfigurator = pictureConfigurator;
            this.builder = builder;
        }

        public void PaintTagCloud(string inputFile, string pictureResultName)
        {
            var words = reader.GetFileData(inputFile)
                .Where(word => contentConfigurator.ValidWord(word.Text))
                .ToList();
            words.Sort((w1, w2) => w2.Quantity.CompareTo(w1.Quantity));
            var picture = new Bitmap(pictureConfigurator.Width, pictureConfigurator.Height);
            using (var g = Graphics.FromImage(picture))
            {
                foreach (var word in words)
                {
                    var fontForWord = GetFont(pictureConfigurator.Painter, words.First().Quantity,
                        words.Last().Quantity, word.Quantity, word.Text);
                    var vertecRectangle = GetVertex(g.MeasureString(word.Text, fontForWord));
                    var rectangle = new RectangleF(vertecRectangle, g.MeasureString(word.Text, fontForWord));
                    var colorForWord = pictureConfigurator.Painter.GetColorWord(word.Text);
                    g.DrawString(
                        word.Text,
                        fontForWord, 
                        new SolidBrush(colorForWord),
                        rectangle);
                }
                picture.Save(pictureResultName);
            }
        }

        internal Font GetFont(IWordPainter pictureConfiguratorPainter, float maxWeight, float minWeight, float weightWord, string word)
        {
            var fontSize = pictureConfiguratorPainter.GetFontSize(word, maxWeight, minWeight, weightWord) + 1;
            return pictureConfiguratorPainter.GetFontWord(word, fontSize);
        }


        internal Point GetVertex(SizeF sizeReactangleForWords)
        {
            var locationRectangle = new Point();
            try
            {
                locationRectangle = builder.GetLocationNextRectangle(Size.Round(sizeReactangleForWords));
            }
            catch (Exception e)
            {
                // ignored
            }
            return locationRectangle;
        }
    }
}

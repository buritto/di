using System;
using System.Drawing;
using System.Linq;
using JetBrains.Annotations;

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

        public void PaintTagCloud(string fileTestName, string pictureResultName)
        {
            var wordsAndCount = reader.GetFileData(fileTestName);
            wordsAndCount.Sort((t1, t2) => t2.Item2.CompareTo(t1.Item2));
            var words = wordsAndCount.Where(tuple => contentConfigurator.ValidWord(tuple.Item1)).ToList();
            var allWords = words.Select(tuple => tuple.Item1).ToList();
            var picture = new Bitmap(pictureConfigurator.Width, pictureConfigurator.Height);
            using (Graphics g = Graphics.FromImage(picture))
            {
                for (int i = 0; i < allWords.Count; i++)
                {
                    var word = allWords[i];
                    var fontForWord = GetFont(pictureConfigurator.Painter, wordsAndCount[0].Item2
                        , wordsAndCount.Last().Item2, wordsAndCount[i].Item2, word);
                    var vertecRectangle = GetVertex(g.MeasureString(word, fontForWord));
                    var rectangle = new RectangleF(vertecRectangle, g.MeasureString(word, fontForWord));
                    var colorForWord = pictureConfigurator.Painter.GetColorWord(word);
                    g.DrawString(
                        word,
                        fontForWord, 
                        new SolidBrush(colorForWord),
                        rectangle);
                }
                picture.Save(pictureResultName);
            }
        }

        private Font GetFont(IWordPainter pictureConfiguratorPainter, float maxWeight, float minWeight, float weightWord, string word)
        {
            var fontSize = pictureConfiguratorPainter.GetFontSize(word, maxWeight, minWeight, weightWord) + 1;
            return pictureConfiguratorPainter.GetFontWord(word, fontSize);
        }


        private Point GetVertex(SizeF sizeReactangleForWords)
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

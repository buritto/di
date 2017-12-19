﻿using System.Drawing;
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

        public TagCloud(
            IFormatReader reader,
            IWordFilter contentConfigurator,
            IPainter pictureConfigurator,
            ITagCloudBuilder builder)
        {
            this.reader = reader;
            this.contentConfigurator = contentConfigurator;
            this.pictureConfigurator = pictureConfigurator;
            this.builder = builder;
        }

        public void PaintTagCloud(string inputFile, string pictureResultName)
        {
            var words = reader.GetFileData(inputFile).TryGetValue()
                .Where(word => contentConfigurator.IsWordValid(word.Text))
                .OrderByDescending(w => w.Quantity)
                .ToArray().AsResult().Then(WordsSequenceIsEmpty);
          
            var maxQuantity = words.TryGetValue().First().Quantity;
            var minQuantity = words.TryGetValue().Last().Quantity;

            var picture = new Bitmap(pictureConfigurator.Width.TryGetValue(), pictureConfigurator.Height.TryGetValue());
            using (var g = Graphics.FromImage(picture))
            {
                foreach (var word in words.TryGetValue())
                {
                    var fontForWord = GetFont(pictureConfigurator.Painter, maxQuantity,
                        minQuantity, word.Quantity, word.Text);
                    
                    var sizeOfWord = g.MeasureString(word.Text, fontForWord);
                    Point leftTopCorner;
                    
                    var resultGetLocation = builder.GetLocationNextRectangle(Size.Round(sizeOfWord));
                    if (resultGetLocation.IsSuccess)
                        leftTopCorner = resultGetLocation.TryGetValue();
                    else
                    {
                        break;
                        
                    }
                     
                    var rectangle = new RectangleF(leftTopCorner, sizeOfWord);
                    var colorForWord = pictureConfigurator.Painter.GetColorWord(word.Text);

                    using (var solidBrush = new SolidBrush(colorForWord))
                        g.DrawString(word.Text, fontForWord, solidBrush, rectangle);
                }
                picture.Save(pictureResultName);
            }
        }

        public static Font GetFont(IWordPainter pictureConfiguratorPainter, float maxWeight, float minWeight, float weightWord, string word)
        {
            var fontSize = pictureConfiguratorPainter.GetFontSize(word, maxWeight, minWeight, weightWord) + 1;
            return pictureConfiguratorPainter.GetFontWord(word, fontSize);
        }

        private Result<Word[]> WordsSequenceIsEmpty(Word[] words)
        {
            return words.Length == 0 ? Result.Fail<Word[]>("Not text, file is empty or not valid text") : words.AsResult();
        }
    }
}

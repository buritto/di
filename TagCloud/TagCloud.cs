namespace TagCloud
{
    class TagCloud
    {
        private string fileName;
        private PictureConfigurator pictureConfigurator;
        private ContentConfigurator contentConfigurator;
        private IFormatReader reader;

        public TagCloud(IFormatReader reader, ContentConfigurator contentConfigurator,
            PictureConfigurator pictureConfigurator, string nameFile)
        {
            this.reader = reader;
            this.contentConfigurator = contentConfigurator;
            this.pictureConfigurator = pictureConfigurator;
            this.fileName = nameFile;
        }
    }
}

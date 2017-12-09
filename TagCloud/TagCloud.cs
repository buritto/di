namespace TagCloud
{
    class TagCloud
    {
        private string fileName;
        private PictureConfigurator pictureConfigurator;
        private ContentConfigurator contentConfigurator;
        private IFormatReader reader;
        private IArchitect architect;

        public TagCloud(IFormatReader reader, ContentConfigurator contentConfigurator,
            PictureConfigurator pictureConfigurator, string fileName, IArchitect architect)
        {
            this.reader = reader;
            this.contentConfigurator = contentConfigurator;
            this.pictureConfigurator = pictureConfigurator;
            this.fileName = fileName;
            this.architect = architect;
        }
    }
}

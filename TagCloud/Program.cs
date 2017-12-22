using System;
using System.Drawing;
using Autofac;

namespace TagCloud
{
    public static class Program
    {
        private static IContainer CreateContainer(Options options)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TxtReader>().As<IFormatReader>();
            builder.Register(c =>
            {
                IWordFilter config = new ContentConfigurator();
                config = config.SetMinCountSymbolInWord(options.Count);
                return (ContentConfigurator) config;
            }).As<IWordFilter>();
            builder.Register(c => new PictureConfigurator(options.Width, options.Height,
                options.Color, options.MaxSizeWord, options.FontStyle)).As<IPainter>();
            var centerWindow = new Point(options.Width / 2, options.Height / 2);
            builder.Register(c => new SpiralBuilder(centerWindow, options.Width, options.Height))
                .As<ITagCloudBuilder>();
            builder.RegisterType<TagCloud>();
            return builder.Build();
        }

        private static void Main(string[] args)
        {
            try
            {
                var options = new Options(args);
                CreateContainer(options)
                    .Resolve<TagCloud>()
                    .PaintTagCloud(options.TextFileName, options.FileNameWithPicture)
                    .EnsureSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
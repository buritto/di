using System.Drawing;
using Autofac;

namespace TagCloud
{
    class Program
    {
        private static void StartTagCloud(int width, int height)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TxtReader>().As<IFormatReader>();
            builder.Register(c => {
                var config = new ContentConfigurator();
                config = config.SetMinCountSymbolInWord(3);
                return config;
            });
            builder.Register(c => new PictureConfigurator(width, height));
            builder.Register(c => new SpiralBuilder(new Point(width / 2, height/2), width, height)).As<IBuilderTagCloud>();
            builder.RegisterType<TagCloud>();
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var component = container.Resolve<TagCloud>();
                component.PaintTagCloud("C:\\data\\Text.txt", "C:\\data\\res.png");
            }
        }

        static void Main(string[] args)
        {
            StartTagCloud(1200, 900);
        }
    }
}

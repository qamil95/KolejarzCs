using SFML.Graphics;
using System.Drawing;
using System.IO;

namespace KolejarzCs.Graphics
{
    internal class TexturesConverter
    {
        public Texture CreateTextureUsingColorArray(string name)
        {
            var image = Properties.Resources.ResourceManager.GetObject(name) as Bitmap;
            SFML.Graphics.Color[,] sfmlcolorarray = new SFML.Graphics.Color[image.Height, image.Width];
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    System.Drawing.Color csharpcolor = image.GetPixel(x, y);
                    sfmlcolorarray[x, y] = new SFML.Graphics.Color(csharpcolor.R, csharpcolor.G, csharpcolor.B, csharpcolor.A);
                }
            }
            SFML.Graphics.Image newimage = new SFML.Graphics.Image(sfmlcolorarray);
            return new Texture(newimage);
        }

        public Texture CreateTextureUsingMemoryStream(string name)
        {
            var image = Properties.Resources.ResourceManager.GetObject(name) as Bitmap;
            MemoryStream stm = new MemoryStream();
            image.Save(stm, System.Drawing.Imaging.ImageFormat.Bmp);
            return new Texture(stm);
        }

        public Texture CreateWhiteTexture()
        {
            SFML.Graphics.Color[,] sfmlcolorarray = new SFML.Graphics.Color[14, 14];
            for (int x = 0; x < 14; x++)
            {
                for (int y = 0; y < 14; y++)
                {
                    System.Drawing.Color csharpcolor = System.Drawing.Color.White;
                    sfmlcolorarray[x, y] = new SFML.Graphics.Color(csharpcolor.R, csharpcolor.G, csharpcolor.B, csharpcolor.A);
                }
            }
            SFML.Graphics.Image newimage = new SFML.Graphics.Image(sfmlcolorarray);
            return new Texture(newimage);
        }
    }
}

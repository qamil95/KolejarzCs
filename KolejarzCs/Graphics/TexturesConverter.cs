using SFML.Graphics;
using System.Drawing;
using System.IO;
using Color = SFML.Graphics.Color;
using Image = SFML.Graphics.Image;

namespace KolejarzCs.Graphics
{
    internal class TexturesConverter
    {
        public Texture LoadTexture(string name)
        {
            var image = Properties.Resources.ResourceManager.GetObject(name) as Bitmap;
            if (image == null)
                return CreateTexture(Color.Red);

            Color[,] sfmlcolorarray = new Color[image.Height, image.Width];
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    System.Drawing.Color csharpcolor = image.GetPixel(x, y);
                    sfmlcolorarray[x, y] = new Color(csharpcolor.R, csharpcolor.G, csharpcolor.B, csharpcolor.A);
                }
            }
            Image newimage = new Image(sfmlcolorarray);
            return new Texture(newimage);
        }

        public Texture LoadTexture2(string name)
        {
            var image = Properties.Resources.ResourceManager.GetObject(name) as Bitmap;
            if (image == null)
                return CreateTexture(Color.Red);

            MemoryStream stm = new MemoryStream();
            image.Save(stm, System.Drawing.Imaging.ImageFormat.Bmp);
            return new Texture(stm);
        }

        public Texture CreateTexture(Color color)
        {
            Color[,] sfmlcolorarray = new Color[14, 14];
            for (int x = 0; x < 14; x++)
            {
                for (int y = 0; y < 14; y++)
                {
                    sfmlcolorarray[x, y] = color;
                }
            }
            Image newimage = new Image(sfmlcolorarray);
            return new Texture(newimage);
        }
    }
}

using SFML.Graphics;
using System.Drawing;
using System.IO;

namespace KolejarzCs.Graphics
{
    internal class TexturesConverter
    {
        public Texture CreateTexture(Bitmap bmp)
        {
            SFML.Graphics.Color[,] sfmlcolorarray = new SFML.Graphics.Color[bmp.Height, bmp.Width];
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    System.Drawing.Color csharpcolor = bmp.GetPixel(x, y);
                    sfmlcolorarray[y, x] = new SFML.Graphics.Color(csharpcolor.R, csharpcolor.G, csharpcolor.B, csharpcolor.A);
                }
            }
            SFML.Graphics.Image newimage = new SFML.Graphics.Image(sfmlcolorarray);
            return new Texture(newimage);
        }

        public Texture CreateTexture2(Bitmap Im)
        {
            MemoryStream stm = new MemoryStream();
            Im.Save(stm, System.Drawing.Imaging.ImageFormat.Bmp);
            return new Texture(stm);
        }
    }
}

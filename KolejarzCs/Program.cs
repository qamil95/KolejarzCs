using KolejarzCs.Parsers;
using KolejarzCs.Properties;
using KolejarzCs.Station;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace KolejarzCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var stationParser = new StationParser();
            var allLines = File.ReadAllLines(@"C:\Gry\Kolejarz\Stacje\Bobowa Miasto\Bobowam.stc");
            var readStation = new List<string[]>();
            foreach (var line in allLines)
            {
                readStation.Add(line.Split(new char [] {','}, StringSplitOptions.RemoveEmptyEntries));
            }
            var station = stationParser.Parse(readStation);



            RenderWindow window = new RenderWindow(new VideoMode(200, 200), "SFML works!");
            CircleShape shape = new CircleShape(100);
            shape.FillColor = SFML.Graphics.Color.Green;

            var rect = new RectangleShape(new SFML.System.Vector2f(14, 14))
            {
                Texture = new Texture(CreateTexture2(Resources.L2))
            };

            window.Closed += Window_Closed;

            while (window.IsOpen)
            {
                window.Clear();
                window.Draw(shape);
                window.Draw(rect);
                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            (sender as Window).Close();
        }

        static Texture CreateTexture2(Bitmap Im)
        {
            MemoryStream stm = new MemoryStream();
            Im.Save(stm, System.Drawing.Imaging.ImageFormat.Png);
            return new Texture(stm);
        }


        private SFML.Graphics.Image ToSFMLImage(Bitmap bmp)
        {
            SFML.Graphics.Color[,] sfmlcolorarray = new SFML.Graphics.Color[bmp.Height, bmp.Width];
            SFML.Graphics.Image newimage = null;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    System.Drawing.Color csharpcolor = bmp.GetPixel(x, y);
                    sfmlcolorarray[y, x] = new SFML.Graphics.Color(csharpcolor.R, csharpcolor.G, csharpcolor.B, csharpcolor.A);
                }
            }
            newimage = new SFML.Graphics.Image(sfmlcolorarray);
            return newimage;
        }

        private SFML.Graphics.Texture ToSFMLTexture(Bitmap bmp)
        {
            return new Texture(ToSFMLImage(bmp));
        }
    }
}

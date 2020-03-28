using KolejarzCs.Graphics;
using KolejarzCs.Parsers;
using KolejarzCs.Station;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;

namespace KolejarzCs
{
    class Program
    {
        private static Vector2f textureSize = new Vector2f(14, 14);

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



            RenderWindow window = new RenderWindow(new VideoMode(1000, 500), "SFML works!");
            CircleShape shape = new CircleShape(100);
            shape.FillColor = Color.Green;

            var rect = new RectangleShape(textureSize);
            rect.Texture = new TexturesDictionary(new TexturesConverter()).GetTexture(DecorationTypes.LETTER_Ł);

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
    }
}

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

        // https://gist.github.com/trlewis/dbb709ecc88667714123
        // http://trlewis.net/hosting-an-sfml-renderwindow-inside-a-wpf-application/

        static void Main(string[] args)
        {
            var stationParser = new StationParser(new ElementBuilder());
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


            var rectangleShapes = new List<RectangleShape>();
            var textures = new TexturesDictionary(new TexturesConverter());

            var position = new Vector2f(0, 100);
            foreach (var stationElenent in station.StationElements)
            {
                var texture = textures.GetTexture(stationElenent);

                var rs = new RectangleShape(textureSize)
                {
                    Position = (Vector2f)stationElenent.Coordinates * 14,
                    Texture = texture
                };
                rectangleShapes.Add(rs);
            }

            window.Closed += (s, a) => window.Close();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();
                window.Draw(shape);
                rectangleShapes.ForEach(x => window.Draw(x));
                window.Display();
            }
        }
    }
}

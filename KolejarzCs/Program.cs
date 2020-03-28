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


            var rectangleShapes = new List<RectangleShape>();
            var textures = new TexturesDictionary(new TexturesConverter());


            var position = new Vector2f();
            foreach (var decoration in (DecorationTypes[])Enum.GetValues(typeof(DecorationTypes)))
            {
                var texture = textures.GetTexture(decoration);
                var rect = new RectangleShape(textureSize);
                rect.Texture = texture;
                rect.Position = position;
                position += new Vector2f(14, 0);
                rectangleShapes.Add(rect);
            }

            position = new Vector2f(0, 14);
            foreach (var track in (TrackTypes[])Enum.GetValues(typeof(TrackTypes)))
            {
                if (track == TrackTypes.EMPTY)
                    continue;

                foreach (var state in (TrackStates[])Enum.GetValues(typeof(TrackStates)))
                {
                    var texture = textures.GetTexture(track, state);
                    var rect = new RectangleShape(textureSize);
                    rect.Texture = texture;
                    rect.Position = position;
                    position += new Vector2f(0, 14);
                    rectangleShapes.Add(rect);
                }
                position.Y = 14;
                position += new Vector2f(14, 0);
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

using KolejarzCs.Parsers;
using KolejarzCs.Properties;
using KolejarzCs.Station;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
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



            RenderWindow window = new RenderWindow(new VideoMode(500, 500), "SFML works!");
            CircleShape shape = new CircleShape(100);
            shape.FillColor = SFML.Graphics.Color.Green;

            window.Closed += Window_Closed;

            while (window.IsOpen)
            {
                window.Clear();
                window.Draw(shape);
                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            (sender as Window).Close();
        }
    }
}

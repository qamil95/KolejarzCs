using System.Collections.Generic;

namespace KolejarzCs.Station
{
    internal class Station
    {
        public Station(int height, int width, List<Element> stationElements)
        {
            Height = height;
            Width = width;
            StationElements = stationElements;
        }

        public int Height { get; }

        public int Width { get; }

        public List<Element> StationElements { get; }
    }
}

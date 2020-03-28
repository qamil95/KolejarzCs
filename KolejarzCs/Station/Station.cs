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

        int Height { get; }

        int Width { get; }

        List<Element> StationElements { get; }
    }
}

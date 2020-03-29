using System.Collections.Generic;

namespace KolejarzCs.Station
{
    internal class Station
    {
        public Station(uint height, uint width, List<Element> stationElements)
        {
            Height = height;
            Width = width;
            StationElements = stationElements;
        }

        public uint Height { get; }

        public uint Width { get; }

        public List<Element> StationElements { get; }
    }
}

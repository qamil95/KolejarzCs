using KolejarzCs.Station;
using SFML.System;
using System;
using System.Collections.Generic;

namespace KolejarzCs.Parsers
{
    class StationParser
    {
        internal Station.Station Parse(List<string[]> readStation)
        {
            int lineIndex = 0;

            var firstLine = int.Parse(readStation[lineIndex++][0]);
            if (firstLine != 0)
            {
                throw new ArgumentException("First line in station file must be zero.");
            }

            var height = int.Parse(readStation[lineIndex++][0]);
            var width = int.Parse(readStation[lineIndex++][0]);

            var stationElements = new List<Element>();

            for (int y=0; y < height; y++, lineIndex++)
            {
                for (int x=0; x < width; x++)
                {
                    stationElements.Add(CreateStationElement(x, y, readStation[lineIndex][x]));
                }
            }

            return new Station.Station(height, width, stationElements);
        }

        private Element CreateStationElement(int x, int y, string type)
        {
            var coordinates = new Vector2i(x, y);

            if (Enum.TryParse<DecorationTypes>(type, out var decorationType))
            {
                return new Decoration(coordinates, decorationType);
            }

            if (Enum.TryParse<TrackTypes>(type, out var trackType))
            {
                return new Track(coordinates, trackType);
            }

            throw new ArgumentOutOfRangeException(nameof(type), "Matching element type not found.");
        }
    }
}

using KolejarzCs.Station;
using SFML.System;
using System;
using System.Collections.Generic;

namespace KolejarzCs.Parsers
{
    class StationParser
    {
        private readonly ElementBuilder elementBuilder;

        public StationParser(ElementBuilder elementBuilder)
        {
            this.elementBuilder = elementBuilder;
        }

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
                    stationElements.Add(elementBuilder.Create(x, y, readStation[lineIndex][x]));
                }
            }

            return new Station.Station(height, width, stationElements);
        }
    }
}

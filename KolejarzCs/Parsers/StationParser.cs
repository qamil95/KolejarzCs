using KolejarzCs.Station;
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

        internal Station.Station Parse(string[] readStation)
        {
            int index = 0;

            var firstElement = int.Parse(readStation[index++]);
            if (firstElement != 0)
            {
                throw new ArgumentException("First line in station file must be zero.");
            }

            var height = uint.Parse(readStation[index++]);
            var width = uint.Parse(readStation[index++]);

            var stationElements = new List<Element>();

            for (int y=0; y < height; y++)
            {
                for (int x=0; x < width; x++)
                {
                    stationElements.Add(elementBuilder.Create(x, y, readStation[index++]));
                }
            }

            return new Station.Station(height, width, stationElements);
        }
    }
}

using SFML.System;
using System;

namespace KolejarzCs.Station
{
    class ElementBuilder
    {
        internal Element Create(int x, int y, string type)
        {
            var coordinates = new Vector2i(x, y);
            var elementType = int.Parse(type);

            if (this.IsDecorationType(elementType))
            {
                return new Decoration(coordinates, (ElementTypes)elementType);
            }

            if (this.IsTrackType(elementType))
            {
                if (this.IsTrackElectric(elementType))
                {
                    return new Track(coordinates, (ElementTypes)elementType, true);
                }
                else
                    return new Track(coordinates, (ElementTypes)(elementType / 10), false);
                
            }

            throw new ArgumentOutOfRangeException(nameof(type), "Matching element type not found.");
        }

        bool IsTrackElectric(int x) => x < 100;

        bool IsDecorationType(int x) => x < 10;

        bool IsTrackType(int x) => x >= 10;
    }
}

using SFML.System;

namespace KolejarzCs.Station
{
    abstract class Element
    {
        public Vector2i Coordinates;

        public Element(Vector2i coordinates)
        {
            Coordinates = coordinates;
        }
    }
}

using SFML.System;

namespace KolejarzCs.Station
{
    abstract class Element
    {
        public Vector2i Coordinates;

        public ElementTypes ElementType;

        public Element(Vector2i coordinates, ElementTypes elememtType)
        {
            Coordinates = coordinates;
            ElementType = elememtType;
        }
    }
}

using SFML.System;

namespace KolejarzCs.Station
{
    class Track : Element
    {
        bool Electric { get; }
        public Track(Vector2i coordinates, ElementTypes elementType, bool electric) : base (coordinates, elementType)
        {
            this.Electric = electric;
        }
    }
}
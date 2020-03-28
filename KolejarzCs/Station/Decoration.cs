using SFML.System;

namespace KolejarzCs.Station
{
    class Decoration : Element
    {
        private DecorationTypes decorationType;

        public Decoration(Vector2i coordinates, DecorationTypes decorationType) : base (coordinates)
        {
            this.decorationType = decorationType;
        }
    }
}

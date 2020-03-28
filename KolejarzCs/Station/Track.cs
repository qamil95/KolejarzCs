using SFML.System;

namespace KolejarzCs.Station
{
    class Track : Element
    {
        private TrackTypes trackType;

        public Track(Vector2i coordinates, TrackTypes trackType) : base (coordinates)
        {
            this.trackType = trackType;
        }
    }
}

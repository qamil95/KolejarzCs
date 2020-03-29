using SFML.System;

namespace KolejarzCs.Station
{
    internal class Track : Element
    {
        public bool Electric { get; }

        public bool Reserved { get; set; }

        public bool Occupied { get; set; }

        public bool Active { get; set; }

        public TrackStates TrackState
        {
            get
            {
                if (this.Active)
                {
                    if (this.Occupied)
                        return TrackStates.OCCUPIED;
                    if (this.Reserved)
                        return TrackStates.RESERVED;
                    return this.Electric ? TrackStates.ELECTRIC : TrackStates.STANDARD;
                }
                else
                {
                    if (this.Occupied)
                        return TrackStates.OCCUPIED_INACTIVE;
                    if (this.Reserved)
                        return TrackStates.RESERVED_INACTIVE;
                    return this.Electric ? TrackStates.ELECTRIC_INACTIVE : TrackStates.STANDARD_INACTIVE;
                }
            }
        }

        public Track(Vector2i coordinates, ElementTypes elementType, bool electric) : base (coordinates, elementType)
        {
            this.Electric = electric;
            this.Active = true;
        }
    }
}
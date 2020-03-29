using KolejarzCs.Station;
using SFML.Graphics;
using System;

namespace KolejarzCs.Graphics
{
    class TexturesDictionary
    {
        public uint TextureHeight { get; }

        public uint TextureWidth { get; }

        private TexturesConverter converter;

        public TexturesDictionary(TexturesConverter converter)
        {
            this.converter = converter;
            this.TextureHeight = 14;
            this.TextureWidth = 14;
        }

        private Texture GetTexture(ElementTypes type)
        {
            var id = (int)type;
            string name;
            if (id > 0)
            {
                name = $"NR{id}";
            }
            else
            {
                name = $"L{-id}";
            }

            return converter.LoadTexture(name);
        }

        private Texture GetTexture(ElementTypes type, TrackStates state)
        {
            var name = $"TOR{(int)type}{(int)state}";
            return converter.LoadTexture(name);
        }

        public Texture GetTexture(Element stationElement)
        {
            if (stationElement.ElementType == ElementTypes.EMPTY)
                return converter.CreateTexture(Color.White);

            if (stationElement is Decoration)
            {
                return GetTexture(stationElement.ElementType);
            }

            if (stationElement is Track trackElement)
            {
                return GetTexture(trackElement.ElementType, trackElement.TrackState);
            }

            throw new ArgumentOutOfRangeException(nameof(stationElement), "Not supported station element.");
        }
    }
}

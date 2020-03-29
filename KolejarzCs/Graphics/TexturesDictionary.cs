using KolejarzCs.Station;
using SFML.Graphics;
using System;

namespace KolejarzCs.Graphics
{
    class TexturesDictionary
    {
        private TexturesConverter converter;

        public TexturesDictionary(TexturesConverter converter)
        {
            this.converter = converter;
        }

        public Texture GetTexture(ElementTypes type)
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

            return converter.CreateTextureUsingColorArray(name);
        }

        public Texture GetTexture(ElementTypes type, TrackStates state)
        {
            var name = $"TOR{(int)type}{(int)state}";
            return converter.CreateTextureUsingColorArray(name);
        }

        public Texture GetTexture(Element stationElement)
        {
            if (stationElement.ElementType == ElementTypes.EMPTY)
                return converter.CreateWhiteTexture();

            if (stationElement is Decoration)
            {
                return GetTexture(stationElement.ElementType);
            }

            if (stationElement is Track)
            {
                return GetTexture(stationElement.ElementType, TrackStates.ELECTRIC);
            }

            throw new ArgumentOutOfRangeException(nameof(stationElement), "Not supported station element.");
        }
    }
}

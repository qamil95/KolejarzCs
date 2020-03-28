using KolejarzCs.Station;
using SFML.Graphics;

namespace KolejarzCs.Graphics
{
    class TexturesDictionary
    {
        private TexturesConverter converter;

        public TexturesDictionary(TexturesConverter converter)
        {
            this.converter = converter;
        }

        public Texture GetTexture(DecorationTypes type)
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

        public Texture GetTexture(TrackTypes type, TrackStates state)
        {
            var name = $"TOR{(int)type}{(int)state}";
            return converter.CreateTextureUsingColorArray(name);
        }
    }
}

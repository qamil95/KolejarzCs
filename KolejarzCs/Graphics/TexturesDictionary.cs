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

        public Texture GetTexture(DecorationTypes type)
        {
            throw new NotImplementedException();
        }

        public Texture GetTexture(TrackTypes type, TrackStates state)
        {
            throw new NotImplementedException();
        }
    }
}

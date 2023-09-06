using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace R3D.Wrapper
{
    class WTexture
    {
        private Texture2D _texture;

        public WTexture(string path)
        {
            _texture = LoadTexture(path);
        }

        public Texture2D Texture { get { return _texture; } }

        public bool Ready { get { return IsTextureReady(_texture); } }

        public TextureFilter Filter { set { SetTextureFilter(_texture, value); } }

        public TextureWrap Wrap { set { SetTextureWrap(_texture, value); } }

        public void Draw(Vector2 position = default, float rotation = 0.0f, float scale = 1.0f)
        {
            DrawTextureEx(_texture, position, rotation, scale, Color.WHITE);
        }

        public void Unload()
        {
            UnloadTexture(_texture);
        }
    }
}

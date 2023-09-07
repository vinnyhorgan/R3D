using R3D.Utility;
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

        public uint Id { get { return _texture.id; } }

        public int Width { get { return _texture.width; } }

        public int Height { get { return _texture.height; } }

        public int Mipmaps { get { return _texture.mipmaps; } }

        public PixelFormat Format { get { return _texture.format; } }

        public TextureFilter Filter { set { SetTextureFilter(_texture, value); } }

        public TextureWrap Wrap { set { SetTextureWrap(_texture, value); } }

        public void Unload()
        {
            UnloadTexture(_texture);
        }

        public void GenMipmaps()
        {
            GenTextureMipmaps(ref _texture);
        }

        public void Draw(Vector2 position = default, float rotation = 0.0f, float scale = 1.0f)
        {
            DrawTextureEx(_texture, position, rotation, scale, Color.WHITE);
        }

        public void DrawRec(Rectangle rec, Vector2 position = default)
        {
            DrawTextureRec(_texture, rec, position, Color.WHITE);
        }

        public void Billboard(rlFPCamera camera, Vector3 position = default, float size = 1.0f)
        {
            DrawBillboard(camera.Camera, _texture, position, size, Color.WHITE);
        }
    }
}

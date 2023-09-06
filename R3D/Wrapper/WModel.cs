using Raylib_cs;
using System.Numerics;

using static Raylib_cs.Raylib;

namespace R3D.Wrapper
{
    class WModel
    {
        private Model _model;

        public WModel(string path)
        {
            _model = LoadModel(path);
        }

        public WModel(WMesh mesh)
        {
            _model = LoadModelFromMesh(mesh.Mesh);
        }

        public Model Model { get { return _model; } }

        public bool Ready { get { return IsModelReady(_model); } }

        public BoundingBox BoundingBox { get { return GetModelBoundingBox(_model); } }

        public WTexture Diffuse
        {
            set
            {
                var texture = value.Texture;
                SetMaterialTexture(ref _model, 0, MaterialMapIndex.MATERIAL_MAP_DIFFUSE, ref texture);
            }
        }

        public WTexture Specular
        {
            set
            {
                var texture = value.Texture;
                SetMaterialTexture(ref _model, 0, MaterialMapIndex.MATERIAL_MAP_SPECULAR, ref texture);
            }
        }

        public WShader Shader
        {
            set
            {
                var shader = value.Shader;
                SetMaterialShader(ref _model, 0, ref shader);
            }
        }

        public void Unload()
        {
            UnloadModel(_model);
        }

        public void Draw(Vector3 position = default, Vector3 rotationAxis = default, float rotationAngle = 0.0f, float scale = 1.0f)
        {
            DrawModelEx(_model, position, rotationAxis, rotationAngle, new Vector3(scale, scale, scale), Color.WHITE);
        }

        public void DrawWires(Vector3 position = default, Vector3 rotationAxis = default, float rotationAngle = 0.0f, float scale = 1.0f)
        {
            DrawModelWiresEx(_model, position, rotationAxis, rotationAngle, new Vector3(scale, scale, scale), Color.WHITE);
        }
    }
}

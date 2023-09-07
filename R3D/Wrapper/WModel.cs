using R3D.Core;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;

using static Raylib_cs.Raylib;

namespace R3D.Wrapper
{
    class WModel
    {
        private Model _model;
        private List<ModelAnimation> _anims;
        private int _currentAnim = 0;
        private int _animCounter = 0;

        public WModel(string path)
        {
            _model = LoadModel(path);

            try
            {
                uint animsCount = 0;
                var anims = LoadModelAnimations(path, ref animsCount);

                _anims = new List<ModelAnimation>((int)animsCount);

                for (uint i = 0; i < animsCount; i++)
                {
                    _anims.Add(anims[(int)i]);
                }

                Logger.Info("Loaded " + _anims.Count + " animations");
            }
            catch (ApplicationException)
            {
                Logger.Info("Model has no animations");
            }
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

                for (int i = 0; i < _model.materialCount; i++)
                {
                    SetMaterialShader(ref _model, i, ref shader);
                }
            }
        }

        public void Unload()
        {
            UnloadModel(_model);

            if (_anims != null)
            {
                foreach (var anim in _anims)
                {
                    UnloadModelAnimation(anim);
                }
            }
        }

        public void Update()
        {
            if (_anims != null && _anims.Count > 0)
            {
                _animCounter++;

                UpdateModelAnimation(_model, _anims[_currentAnim], _animCounter);

                if (_animCounter >= _anims[_currentAnim].frameCount)
                {
                    _animCounter = 0;
                }
            }
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

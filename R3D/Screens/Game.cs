using ImGuiNET;
using R3D.Core;
using R3D.Utility;
using R3D.Wrapper;
using Raylib_cs;
using System.Numerics;

using static Raylib_cs.Raylib;

namespace R3D.Screens
{
    class Game : Screen
    {
        private rlFPCamera _camera;
        private WModel _cube;
        private WModel _light;
        private WTexture _diffuse;
        private WTexture _specular;
        private WShader _test;
        private Vector3 _lightPos;

        public unsafe override void Load()
        {
            _camera = new rlFPCamera();
            _camera.Setup(45.0f, new Vector3(5.0f, 5.0f, 5.0f));
            _camera.MoveSpeed.Z = 10;
            _camera.MoveSpeed.X = 5;
            _camera.MoveSpeed.Y = 10;

            _cube = new WModel(WMesh.Cube(1.0f, 1.0f, 1.0f));
            _light = new WModel(WMesh.Cube(0.2f, 0.2f, 0.2f));

            _diffuse = new WTexture("Assets/Textures/container2.png");
            _specular = new WTexture("assets/Textures/container2_specular.png");

            _test = new WShader("Assets/Shaders/test.vs", "Assets/Shaders/test.fs");

            _cube.Diffuse = _diffuse;
            _cube.Specular = _specular;

            _cube.Shader = _test;

            _test.Set("light.ambient", new Vector3(0.2f, 0.2f, 0.2f));
            _test.Set("light.diffuse", new Vector3(1.0f, 1.0f, 1.0f));
            _test.Set("light.specular", new Vector3(1.0f, 1.0f, 1.0f));
            _test.Set("shininess", 64.0f);

            MaximizeWindow();

            _lightPos = new Vector3(2.0f, 2.0f, 2.0f);
        }

        public override void Update(float dt)
        {
            _camera.Update();

            _test.Set("light.position", _lightPos);
            _test.Set("viewPos", _camera.GetCameraPosition());

            ImGui.Begin("Controls");

            ImGui.SliderFloat3("Light Position", ref _lightPos, -10.0f, 10.0f);

            ImGui.End();
        }

        public override void Draw()
        {
            _camera.BeginMode3D();

            DrawGrid(10, 1);

            _cube.Draw();
            _light.Draw(_lightPos);

            _camera.EndMode3D();

        }

        public override void Unload()
        {
            _cube.Unload();
            _light.Unload();

            _diffuse.Unload();
            _specular.Unload();

            _test.Unload();
        }
    }
}

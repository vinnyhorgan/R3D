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
        private WModel _ironman;
        private WModel _robot;
        private WModel _light;
        private WModel _ground;

        private WTexture _diffuse;
        private WTexture _specular;

        private WTexture _ironmanDiffuse;
        private WTexture _ironmanSpecular;
        private WTexture _robotDiffuse;

        private WTexture _groundDiffuse;

        private WShader _test;

        private Vector3 _lightPos;

        private bool _inGame = true;

        private bool _filter = false;

        public unsafe override void Load()
        {
            _camera = new rlFPCamera();
            _camera.Setup(45.0f, new Vector3(5.0f, 5.0f, 5.0f));
            _camera.MoveSpeed.Z = 10;
            _camera.MoveSpeed.X = 5;
            _camera.MoveSpeed.Y = 10;

            _cube = new WModel(WMesh.Cube(1.0f, 1.0f, 1.0f));
            _ironman = new WModel("Assets/Models/ironman.obj");
            _robot = new WModel("Assets/Models/rick.glb");
            _light = new WModel(WMesh.Cube(0.2f, 0.2f, 0.2f));
            _ground = new WModel(WMesh.Plane(20.0f, 20.0f, 1, 1));

            _diffuse = new WTexture("Assets/Textures/container2.png");
            _specular = new WTexture("assets/Textures/container2_specular.png");

            _ironmanDiffuse = new WTexture("Assets/Textures/ironman_diffuse.png");
            _ironmanSpecular = new WTexture("Assets/Textures/ironman_specular.png");

            _groundDiffuse = new WTexture("Assets/Textures/floor.png");

            _test = new WShader("Assets/Shaders/test.vs", "Assets/Shaders/test.fs");

            _lightPos = new Vector3(2.0f, 2.0f, 2.0f);

            _cube.Diffuse = _diffuse;
            _cube.Specular = _specular;
            _cube.Shader = _test;

            _ironman.Diffuse = _ironmanDiffuse;
            _ironman.Specular = _ironmanSpecular;
            _ironman.Shader = _test;

            _ground.Diffuse = _groundDiffuse;
            _ground.Shader = _test;

            _robot.Shader = _test;

            _test.Set("light.ambient", new Vector3(0.2f, 0.2f, 0.2f));
            _test.Set("light.diffuse", new Vector3(1.0f, 1.0f, 1.0f));
            _test.Set("light.specular", new Vector3(1.0f, 1.0f, 1.0f));
            _test.Set("shininess", 64.0f);

            MaximizeWindow();
        }

        public override void Update(float dt)
        {
            _test.Set("light.position", _lightPos);
            _test.Set("viewPos", _camera.GetCameraPosition());

            _robot.Update();

            if (_inGame)
            {
                _camera.Update();
            }

            if (IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                if (_inGame)
                {
                    _inGame = false;
                    EnableCursor();
                }
                else
                {
                    _inGame = true;
                    DisableCursor();
                }
            }

            ImGui.Begin("Controls");

            ImGui.SliderFloat3("Light Position", ref _lightPos, -10.0f, 10.0f);

            if (ImGui.Checkbox("Filter", ref _filter))
            {
                if (_filter)
                {
                    _diffuse.Filter = TextureFilter.TEXTURE_FILTER_BILINEAR;
                    _ironmanDiffuse.Filter = TextureFilter.TEXTURE_FILTER_BILINEAR;
                }
                else
                {
                    _diffuse.Filter = TextureFilter.TEXTURE_FILTER_POINT;
                    _ironmanDiffuse.Filter = TextureFilter.TEXTURE_FILTER_POINT;
                }
            }

            ImGui.End();
        }

        public override void Draw()
        {
            _camera.BeginMode3D();

            _cube.Draw();
            _ironman.Draw(new Vector3(3.0f, 0.0f, 3.0f));
            _robot.Draw(new Vector3(-3.0f, 0.0f, -3.0f), new Vector3(1.0f, 0.0f, 0.0f), 90, 0.02f);
            _light.Draw(_lightPos);
            _ground.Draw();

            _diffuse.Billboard(_camera, new Vector3(10.0f, 0.0f, 10.0f));

            _camera.EndMode3D();

            DrawFPS(10, 10);
        }

        public override void Unload()
        {
            _cube.Unload();
            _ironman.Unload();
            _robot.Unload();
            _light.Unload();

            _diffuse.Unload();
            _specular.Unload();

            _ironmanDiffuse.Unload();
            _ironmanSpecular.Unload();

            _test.Unload();
        }
    }
}

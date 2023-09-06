using Raylib_cs;
using R3D.Screens;
using R3D.Utility;

using static Raylib_cs.Raylib;

namespace R3D.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 800;
            int height = 600;

            Logger.Init(true);

            SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE | ConfigFlags.FLAG_MSAA_4X_HINT);
            InitWindow(width, height, "R3D");
            SetWindowMinSize(width / 2, height / 2);
            SetExitKey(KeyboardKey.KEY_NULL);
            SetTargetFPS(GetMonitorRefreshRate(GetCurrentMonitor()));

            InitAudioDevice();

            var controller = new ImguiController();
            controller.Load(width, height);

            ScreenManager.Instance.LoadScreen(new Game());

            while (!WindowShouldClose())
            {
                float dt = GetFrameTime();

                controller.Update(dt);

                ScreenManager.Instance.Update(dt);

                BeginDrawing();

                ClearBackground(Color.BLACK);

                ScreenManager.Instance.Draw();

                controller.Draw();

                EndDrawing();
            }

            ScreenManager.Instance.Unload();

            controller.Dispose();

            CloseAudioDevice();

            CloseWindow();
        }
    }
}

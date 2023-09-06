namespace R3D.Core
{
    class ScreenManager
    {
        private static ScreenManager _instance;

        private Screen _currentScreen;

        private ScreenManager() { }

        public static ScreenManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScreenManager();
                }

                return _instance;
            }
        }

        public void LoadScreen(Screen screen)
        {
            _currentScreen?.Unload();

            screen.Load();

            _currentScreen = screen;
        }

        public void Update(float dt)
        {
            _currentScreen?.Update(dt);
        }

        public void Draw()
        {
            _currentScreen?.Draw();
        }

        public void Unload()
        {
            _currentScreen?.Unload();
        }
    }
}

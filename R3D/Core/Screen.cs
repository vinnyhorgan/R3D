namespace R3D.Core
{
    class Screen
    {
        public ScreenManager ScreenManager
        {
            get { return ScreenManager.Instance; }
        }

        public virtual void Load() { }
        public virtual void Update(float dt) { }
        public virtual void Draw() { }
        public virtual void Unload() { }
    }
}

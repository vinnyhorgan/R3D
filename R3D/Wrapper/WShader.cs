using Raylib_cs;
using System.Numerics;

using static Raylib_cs.Raylib;

namespace R3D.Wrapper
{
    class WShader
    {
        private Shader _shader;

        public WShader(string vsPath, string fsPath)
        {
            _shader = LoadShader(vsPath, fsPath);
        }

        public Shader Shader { get { return _shader; } }

        public bool Ready { get { return IsShaderReady(_shader); } }

        public void Unload()
        {
            UnloadShader(_shader);
        }

        public void Set(string uniform, float value)
        {
            SetShaderValue(_shader, GetShaderLocation(_shader, uniform), value, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
        }

        public void Set(string uniform, Vector3 value)
        {
            SetShaderValue(_shader, GetShaderLocation(_shader, uniform), value, ShaderUniformDataType.SHADER_UNIFORM_VEC3);
        }

        public void Begin()
        {
            BeginShaderMode(_shader);
        }

        public void End()
        {
            EndShaderMode();
        }
    }
}

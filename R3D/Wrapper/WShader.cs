using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;

using static Raylib_cs.Raylib;

namespace R3D.Wrapper
{
    class WShader
    {
        private Shader _shader;

        private Dictionary<string, int> _uniforms = new();

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

        public void Set(string uniform, int value)
        {
            int location;

            if (_uniforms.ContainsKey(uniform))
            {
                location = _uniforms[uniform];
            }
            else
            {
                location = GetShaderLocation(_shader, uniform);
                _uniforms.Add(uniform, location);
            }

            SetShaderValue(_shader, location, value, ShaderUniformDataType.SHADER_UNIFORM_INT);
        }

        public void Set(string uniform, float value)
        {
            int location;

            if (_uniforms.ContainsKey(uniform))
            {
                location = _uniforms[uniform];
            }
            else
            {
                location = GetShaderLocation(_shader, uniform);
                _uniforms.Add(uniform, location);
            }

            SetShaderValue(_shader, location, value, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
        }

        public void Set(string uniform, Vector2 value)
        {
            int location;

            if (_uniforms.ContainsKey(uniform))
            {
                location = _uniforms[uniform];
            }
            else
            {
                location = GetShaderLocation(_shader, uniform);
                _uniforms.Add(uniform, location);
            }

            SetShaderValue(_shader, location, value, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
        }

        public void Set(string uniform, Vector3 value)
        {
            int location;

            if (_uniforms.ContainsKey(uniform))
            {
                location = _uniforms[uniform];
            }
            else
            {
                location = GetShaderLocation(_shader, uniform);
                _uniforms.Add(uniform, location);
            }

            SetShaderValue(_shader, location, value, ShaderUniformDataType.SHADER_UNIFORM_VEC3);
        }

        public void Set(string uniform, Vector4 value)
        {
            int location;

            if (_uniforms.ContainsKey(uniform))
            {
                location = _uniforms[uniform];
            }
            else
            {
                location = GetShaderLocation(_shader, uniform);
                _uniforms.Add(uniform, location);
            }

            SetShaderValue(_shader, location, value, ShaderUniformDataType.SHADER_UNIFORM_VEC4);
        }

        public void Set(string uniform, Matrix4x4 value)
        {
            int location;

            if (_uniforms.ContainsKey(uniform))
            {
                location = _uniforms[uniform];
            }
            else
            {
                location = GetShaderLocation(_shader, uniform);
                _uniforms.Add(uniform, location);
            }

            SetShaderValueMatrix(_shader, location, value);
        }

        public void Set(string uniform, WTexture value)
        {
            int location;

            if (_uniforms.ContainsKey(uniform))
            {
                location = _uniforms[uniform];
            }
            else
            {
                location = GetShaderLocation(_shader, uniform);
                _uniforms.Add(uniform, location);
            }

            SetShaderValueTexture(_shader, location, value.Texture);
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

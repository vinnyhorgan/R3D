using Raylib_cs;

using static Raylib_cs.Raylib;

namespace R3D.Wrapper
{
    class WMesh
    {
        private Mesh _mesh;

        public WMesh()
        {

        }

        public Mesh Mesh { get { return _mesh; } }

        public BoundingBox BoundingBox { get { return GetMeshBoundingBox(_mesh); } }

        public static WMesh Poly(int sides, float radius)
        {
            var mesh = new WMesh();
            mesh._mesh = GenMeshPoly(sides, radius);

            return mesh;
        }

        public static WMesh Plane(float width, float length, int resX, int resZ)
        {
            var mesh = new WMesh();
            mesh._mesh = GenMeshPlane(width, length, resX, resZ);

            return mesh;
        }

        public static WMesh Cube(float width, float height, float length)
        {
            var mesh = new WMesh();
            mesh._mesh = GenMeshCube(width, height, length);

            return mesh;
        }

        // ...

        public void Unload()
        {
            UnloadMesh(ref _mesh);
        }
    }
}

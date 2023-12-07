using Silk.NET.Maths;

namespace WPF_3D_Graphics._3D_Graphics;

public struct Vertex(Vector3D<float> position, Vector3D<float> normal, Vector2D<float> texCoords)
{
    public Vector3D<float> Position = position;

    public Vector3D<float> Normal = normal;

    public Vector2D<float> TexCoords = texCoords;
}

using Silk.NET.Maths;
using System.Windows.Media;

namespace WPF_3D_Graphics._3D_Graphics;

public class Plane : BaseModel
{
    public Plane(Brush diffuse, Brush specular) : this(diffuse, specular, new Vector2D<float>(1, 1))
    {
    }

    public Plane(Brush diffuse, Brush specular, Vector2D<float> textureScale)
    {
        Vertex[] vertices =
        [
            new Vertex(new Vector3D<float>(-0.5f,  0.0f, -0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>( 0.5f,  0.0f, -0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>( 0.5f,  0.0f,  0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>( 0.5f,  0.0f,  0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(-0.5f,  0.0f,  0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(0.0f, 0.0f)),
            new Vertex(new Vector3D<float>(-0.5f,  0.0f, -0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f))
        ];

        uint[] indices = vertices.Select((a, b) => (uint)b).ToArray();

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].TexCoords.X *= textureScale.X;
            vertices[i].TexCoords.Y *= textureScale.Y;
        }

        Meshes =
        [
            new Mesh(vertices, indices, diffuse, specular)
        ];
    }

    public override Mesh[] Meshes { get; }
}

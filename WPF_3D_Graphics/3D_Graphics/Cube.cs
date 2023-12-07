using Silk.NET.Maths;
using System.Windows.Media;

namespace WPF_3D_Graphics._3D_Graphics;

public class Cube : BaseModel
{
    public Cube(Brush diffuse, Brush specular)
    {
        Vertex[] vertices =
        [

            // Front face
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, 0.5f), new Vector3D<float>(0.0f, 0.0f, -1.0f), new Vector2D<float>(0.0f, 0.0f)),
            new Vertex(new Vector3D<float>(0.5f, -0.5f, 0.5f), new Vector3D<float>(0.0f, 0.0f, -1.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, 0.5f), new Vector3D<float>(0.0f, 0.0f, -1.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, 0.5f), new Vector3D<float>(0.0f, 0.0f, -1.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>(-0.5f, 0.5f, 0.5f), new Vector3D<float>(0.0f, 0.0f, -1.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, 0.5f), new Vector3D<float>(0.0f, 0.0f, -1.0f), new Vector2D<float>(0.0f, 0.0f)),

            // Back face
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, -0.5f), new Vector3D<float>(0.0f, 0.0f, 1.0f), new Vector2D<float>(0.0f, 0.0f)),
            new Vertex(new Vector3D<float>(0.5f, -0.5f, -0.5f), new Vector3D<float>(0.0f, 0.0f, 1.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, -0.5f), new Vector3D<float>(0.0f, 0.0f, 1.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, -0.5f), new Vector3D<float>(0.0f, 0.0f, 1.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>(-0.5f, 0.5f, -0.5f), new Vector3D<float>(0.0f, 0.0f, 1.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, -0.5f), new Vector3D<float>(0.0f, 0.0f, 1.0f), new Vector2D<float>(0.0f, 0.0f)),

            // Left face
            new Vertex(new Vector3D<float>(-0.5f, 0.5f, 0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(-0.5f, 0.5f, -0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, -0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, -0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, 0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(0.0f, 0.0f)),
            new Vertex(new Vector3D<float>(-0.5f, 0.5f, 0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),

            // Right face
            new Vertex(new Vector3D<float>(0.5f, 0.5f, 0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, -0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, -0.5f, -0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, -0.5f, -0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, -0.5f, 0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(0.0f, 0.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, 0.5f), new Vector3D<float>(-1.0f, 0.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),

            // Bottom face
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, -0.5f), new Vector3D<float>(0.0f, 1.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, -0.5f, -0.5f), new Vector3D<float>(0.0f, 1.0f, 0.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, -0.5f, 0.5f), new Vector3D<float>(0.0f, 1.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(0.5f, -0.5f, 0.5f), new Vector3D<float>(0.0f, 1.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, 0.5f), new Vector3D<float>(0.0f, 1.0f, 0.0f), new Vector2D<float>(0.0f, 0.0f)),
            new Vertex(new Vector3D<float>(-0.5f, -0.5f, -0.5f), new Vector3D<float>(0.0f, 1.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f)),

            // Top face
            new Vertex(new Vector3D<float>(-0.5f, 0.5f, -0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, -0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(1.0f, 1.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, 0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(0.5f, 0.5f, 0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(1.0f, 0.0f)),
            new Vertex(new Vector3D<float>(-0.5f, 0.5f, 0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(0.0f, 0.0f)),
            new Vertex(new Vector3D<float>(-0.5f, 0.5f, -0.5f), new Vector3D<float>(0.0f, -1.0f, 0.0f), new Vector2D<float>(0.0f, 1.0f))
        ];

        uint[] indices = vertices.Select((a, b) => (uint)b).ToArray();

        Meshes =
        [
            new Mesh(vertices, indices, diffuse, specular)
        ];
    }

    public override Mesh[] Meshes { get; }
}

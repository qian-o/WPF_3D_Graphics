using System.Windows.Media;

namespace WPF_3D_Graphics._3D_Graphics;

public class Mesh(Vertex[] vertices, uint[] indices, Brush diffuse, Brush specular)
{
    public Vertex[] Vertices { get; } = vertices;

    public uint[] Indices { get; } = indices;

    public Brush Diffuse { get; } = diffuse;

    public Brush Specular { get; } = specular;
}

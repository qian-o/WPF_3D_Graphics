using Silk.NET.Maths;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using WPF_3D_Graphics.Helpers;

namespace WPF_3D_Graphics._3D_Graphics;

public abstract class BaseModel
{
    private ModelVisual3D? modelVisual;

    private Matrix4X4<float> transform = Matrix4X4<float>.Identity;

    public abstract Mesh[] Meshes { get; }

    public Matrix4X4<float> Transform
    {
        get => transform;
        set
        {
            transform = value;

            if (modelVisual is not null)
            {
                modelVisual.Transform = new MatrixTransform3D(Transform.ToMatrix3D());
            }
        }
    }

    public ModelVisual3D GetModelVisual()
    {
        if (modelVisual is null)
        {
            modelVisual = new ModelVisual3D();

            Model3DGroup group = new();
            foreach (Mesh mesh in Meshes)
            {
                group.Children.Add(ConvertGeometryModel(mesh));
            }

            modelVisual.Content = group;

            modelVisual.Transform = new MatrixTransform3D(Transform.ToMatrix3D());
        }

        return modelVisual;
    }

    private static GeometryModel3D ConvertGeometryModel(Mesh mesh)
    {
        GeometryModel3D geometryModel = new();

        MeshGeometry3D meshGeometry = new();

        // 顶点
        {
            // 坐标、法线、纹理坐标
            {
                Point3DCollection positions = [];
                Vector3DCollection normals = [];
                PointCollection textureCoordinates = [];
                foreach (Vertex vertex in mesh.Vertices)
                {
                    positions.Add(vertex.Position.ToPoint3D());
                    normals.Add(vertex.Normal.ToVector3D());
                    textureCoordinates.Add(vertex.TexCoords.ToPoint());
                }
                meshGeometry.Positions = positions;
                meshGeometry.Normals = normals;
                meshGeometry.TextureCoordinates = textureCoordinates;
            }

            // 索引
            {
                Int32Collection indices = [];
                foreach (uint index in mesh.Indices)
                {
                    indices.Add((int)index);
                }
                meshGeometry.TriangleIndices = indices;
            }

            geometryModel.Geometry = meshGeometry;
        }

        // 材质
        {
            MaterialGroup materialGroup = new();

            // 漫反射
            {
                DiffuseMaterial diffuseMaterial = new()
                {
                    Brush = mesh.Diffuse
                };
                materialGroup.Children.Add(diffuseMaterial);
            }

            // 镜面反射
            {
                SpecularMaterial specularMaterial = new()
                {
                    Brush = mesh.Specular,
                    SpecularPower = 16
                };
                materialGroup.Children.Add(specularMaterial);
            }

            geometryModel.Material = materialGroup;
            geometryModel.BackMaterial = materialGroup;
        }

        return geometryModel;
    }
}
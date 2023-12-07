using Silk.NET.Maths;
using System.Windows;
using System.Windows.Media.Media3D;
using Vector3D = System.Windows.Media.Media3D.Vector3D;

namespace WPF_3D_Graphics.Helpers;

public static class MathExtensions
{
    public static Point3D ToPoint3D(this Vector3D<float> vector)
    {
        return new Point3D(vector.X, vector.Y, vector.Z);
    }

    public static Vector3D ToVector3D(this Vector3D<float> vector)
    {
        return new Vector3D(vector.X, vector.Y, vector.Z);
    }

    public static Point ToPoint(this Vector2D<float> vector)
    {
        return new Point(vector.X, vector.Y);
    }

    public static Matrix3D ToMatrix3D(this Matrix4X4<float> matrix)
    {
        return new Matrix3D
        {
            M11 = matrix.M11,
            M12 = matrix.M12,
            M13 = matrix.M13,
            M14 = matrix.M14,
            M21 = matrix.M21,
            M22 = matrix.M22,
            M23 = matrix.M23,
            M24 = matrix.M24,
            M31 = matrix.M31,
            M32 = matrix.M32,
            M33 = matrix.M33,
            M34 = matrix.M34,
            OffsetX = matrix.M41,
            OffsetY = matrix.M42,
            OffsetZ = matrix.M43,
            M44 = matrix.M44
        };
    }
}

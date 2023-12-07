using System.Numerics;
using System.Windows.Media.Media3D;
using WPF_3D_Graphics.Helpers;

namespace WPF_3D_Graphics._3D_Graphics;

public class Camera
{
    private Vector3 front = -Vector3.UnitZ;
    private Vector3 up = Vector3.UnitY;
    private Vector3 right = Vector3.UnitX;
    private float pitch;
    private float yaw = -MathHelper.PiOver2;
    private float fov = MathHelper.PiOver2;

    public Camera()
    {
        PerspectiveCamera = new()
        {
            NearPlaneDistance = 0.1,
            FarPlaneDistance = 1000,
            FieldOfView = 45
        };
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public Vector3 Position { get; set; } = new(0.0f, 0.0f, 0.0f);

    public Vector3 Front => front;

    public Vector3 Up => up;

    public Vector3 Right => right;

    public PerspectiveCamera PerspectiveCamera { get; }

    public float Pitch
    {
        get => MathHelper.RadiansToDegrees(pitch);
        set
        {
            pitch = MathHelper.DegreesToRadians(MathHelper.Clamp(value, -89f, 89f));

            UpdateVectors();
        }
    }

    public float Yaw
    {
        get => MathHelper.RadiansToDegrees(yaw);
        set
        {
            yaw = MathHelper.DegreesToRadians(value);

            UpdateVectors();
        }
    }

    public float Fov
    {
        get => MathHelper.RadiansToDegrees(fov);
        set
        {
            fov = MathHelper.DegreesToRadians(MathHelper.Clamp(value, 1f, 90f));
        }
    }

    private void UpdateVectors()
    {
        front.X = MathF.Cos(pitch) * MathF.Cos(yaw);
        front.Y = MathF.Sin(pitch);
        front.Z = MathF.Cos(pitch) * MathF.Sin(yaw);

        front = Vector3.Normalize(front);

        right = Vector3.Normalize(Vector3.Cross(front, Vector3.UnitY));
        up = Vector3.Normalize(Vector3.Cross(right, front));
    }

    public void Update()
    {
        PerspectiveCamera.LookDirection = new Vector3D(front.X, front.Y, front.Z);
        PerspectiveCamera.UpDirection = new Vector3D(up.X, up.Y, up.Z);
        PerspectiveCamera.Position = new Point3D(Position.X, Position.Y, Position.Z);
    }
}

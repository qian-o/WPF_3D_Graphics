using Silk.NET.Maths;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPF_3D_Graphics._3D_Graphics;
using Plane = WPF_3D_Graphics._3D_Graphics.Plane;

namespace WPF_3D_Graphics;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Plane _plane;
    private readonly Cube _cube;
    private readonly Cube _pointLight1;
    private readonly Cube _pointLight2;
    private readonly Cube _pointLight3;

    public MainWindow()
    {
        InitializeComponent();

        _plane = new Plane(GetTex("Textures/wood_floor.jpg"), GetTex("Textures/wood_floor.jpg"), new Vector2D<float>(5000.0f));
        _cube = new(GetTex("Textures/container2.png"), GetTex("Textures/container2_specular.png"));
        _pointLight1 = new Cube(GetTex(Colors.Red), GetTex(Colors.White));
        _pointLight2 = new Cube(GetTex(Colors.Green), GetTex(Colors.White));
        _pointLight3 = new Cube(GetTex(Colors.Blue), GetTex(Colors.White));

        Scene.AddModel(_plane);
        Scene.AddModel(_cube);
        Scene.AddModel(_pointLight1);
        Scene.AddModel(_pointLight2);
        Scene.AddModel(_pointLight3);

        Scene.AddDirectionalLight(Color.FromRgb(232, 222, 196), new System.Windows.Media.Media3D.Vector3D(1, -1, 1));
        Scene.AddPointLight(Colors.Red, new System.Windows.Media.Media3D.Point3D(0, 1.505f, -1.0f));
        Scene.AddPointLight(Colors.Green, new System.Windows.Media.Media3D.Point3D(-1.0f, 1.505f, 0.0));
        Scene.AddPointLight(Colors.Blue, new System.Windows.Media.Media3D.Point3D(1.0f, 1.505f, 0.0));
    }

    private void Scene_Update(object arg1, TimeSpan arg2)
    {
        _plane.Transform = Matrix4X4.CreateScale(10000.0f);
        _cube.Transform = Matrix4X4.CreateTranslation(0.0f, 0.505f, 0.0f);
        _pointLight1.Transform = Matrix4X4.CreateScale(0.1f) * Matrix4X4.CreateTranslation(0.0f, 1.505f, -1.0f);
        _pointLight2.Transform = Matrix4X4.CreateScale(0.1f) * Matrix4X4.CreateTranslation(-1.0f, 1.505f, 0.0f);
        _pointLight3.Transform = Matrix4X4.CreateScale(0.1f) * Matrix4X4.CreateTranslation(1.0f, 1.505f, 0.0f);
    }

    private static ImageBrush GetTex(string path)
    {
        ImageBrush imageBrush = new(new BitmapImage(new Uri(path, UriKind.Relative)))
        {
            TileMode = TileMode.Tile,
            ViewportUnits = BrushMappingMode.Absolute
        };
        imageBrush.Freeze();

        return imageBrush;
    }

    private static SolidColorBrush GetTex(Color color)
    {
        SolidColorBrush solidColorBrush = new(color);
        solidColorBrush.Freeze();

        return solidColorBrush;
    }

    private static LinearGradientBrush GetTex(Color[] colors, Point begin, Point end)
    {
        LinearGradientBrush linearGradientBrush = new();
        double step = 1.0 / (colors.Length - 1);
        for (int i = 0; i < colors.Length; i++)
        {
            linearGradientBrush.GradientStops.Add(new GradientStop(colors[i], i * step));
        }
        linearGradientBrush.StartPoint = begin;
        linearGradientBrush.EndPoint = end;
        linearGradientBrush.Freeze();

        return linearGradientBrush;
    }
}
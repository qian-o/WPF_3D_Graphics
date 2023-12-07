using System.Diagnostics;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WPF_3D_Graphics._3D_Graphics;

public class Scene : ContentControl
{
    public static readonly DependencyProperty FpsProperty = DependencyProperty.Register(nameof(Fps), typeof(int), typeof(Scene), new PropertyMetadata(0));

    private readonly Viewport3D _viewport3D;
    private readonly Camera _camera;
    private readonly float cameraSpeed = 1.2f;
    private readonly float sensitivity = 0.2f;
    private readonly ModelVisual3D _modelVisual;
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
    private readonly List<int> _fpsSample = [];

    private TimeSpan lastRenderTime = TimeSpan.FromSeconds(-1);
    private TimeSpan lastFrameStamp;

    private bool firstMove = true;
    private Vector2 lastPos;

    public event Action<object, TimeSpan>? Update;

    public Scene()
    {
        _viewport3D = new Viewport3D();
        _camera = new Camera()
        {
            Position = new Vector3(0, 1, 8)
        };
        _modelVisual = new ModelVisual3D();

        Content = _viewport3D;

        IsVisibleChanged += (_, e) =>
        {
            if ((bool)e.NewValue)
            {
                CompositionTarget.Rendering += CompositionTarget_Rendering;
            }
            else
            {
                CompositionTarget.Rendering -= CompositionTarget_Rendering;
            }
        };
        Update += Scene_Update;

        LoadScene();
    }

    public int Fps
    {
        get { return (int)GetValue(FpsProperty); }
        set { SetValue(FpsProperty, value); }
    }

    /// <summary>
    /// 初始化场景。
    /// 默认添加一个全局的环境光。
    /// </summary>
    private void LoadScene()
    {
        _viewport3D.Camera = _camera.PerspectiveCamera;
        _viewport3D.Children.Add(_modelVisual);

        // 添加一个全局的环境光
        _modelVisual.Children.Add(PackageModel3D(new AmbientLight(Color.Multiply(Colors.White, 0.1f))));
    }

    private void CompositionTarget_Rendering(object? sender, EventArgs e)
    {
        RenderingEventArgs args = (RenderingEventArgs)e;

        if (lastRenderTime != args.RenderingTime)
        {
            InvalidateVisual();

            _fpsSample.Add(Convert.ToInt32(1000.0d / (args.RenderingTime.TotalMilliseconds - lastRenderTime.TotalMilliseconds)));

            if (_fpsSample.Count == 60)
            {
                Fps = Convert.ToInt32(_fpsSample.Average());
                _fpsSample.Clear();
            }

            lastRenderTime = args.RenderingTime;
        }
    }

    private void Scene_Update(object arg1, TimeSpan arg2)
    {
        if (Keyboard.IsKeyDown(Key.W))
        {
            _camera.Position += _camera.Front * cameraSpeed * (float)arg2.TotalSeconds;
        }
        if (Keyboard.IsKeyDown(Key.S))
        {
            _camera.Position -= _camera.Front * cameraSpeed * (float)arg2.TotalSeconds;
        }
        if (Keyboard.IsKeyDown(Key.A))
        {
            _camera.Position -= _camera.Right * cameraSpeed * (float)arg2.TotalSeconds;
        }
        if (Keyboard.IsKeyDown(Key.D))
        {
            _camera.Position += _camera.Right * cameraSpeed * (float)arg2.TotalSeconds;
        }
        if (Keyboard.IsKeyDown(Key.E))
        {
            _camera.Position += _camera.Up * cameraSpeed * (float)arg2.TotalSeconds;
        }
        if (Keyboard.IsKeyDown(Key.Q))
        {
            _camera.Position -= _camera.Up * cameraSpeed * (float)arg2.TotalSeconds;
        }

        if (Mouse.MiddleButton == MouseButtonState.Pressed)
        {
            Cursor = Cursors.None;

            Point point = Mouse.GetPosition((Control)arg1);
            float x = Convert.ToSingle(point.X);
            float y = Convert.ToSingle(point.Y);

            if (firstMove)
            {
                lastPos = new Vector2(x, y);
                firstMove = false;
            }
            else
            {
                var deltaX = x - lastPos.X;
                var deltaY = y - lastPos.Y;
                lastPos = new Vector2(x, y);

                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }
        }
        else
        {
            Cursor = null;

            firstMove = true;
        }

        _camera.Update();
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        Update?.Invoke(this, _stopwatch.Elapsed - lastFrameStamp);

        base.OnRender(drawingContext);

        lastFrameStamp = _stopwatch.Elapsed;
    }

    /// <summary>
    /// 添加方向光。
    /// </summary>
    /// <param name="color">color</param>
    /// <param name="vector">vector</param>
    public void AddDirectionalLight(Color color, Vector3D vector)
    {
        DirectionalLight light = new(color, vector);

        _modelVisual.Children.Add(PackageModel3D(light));
    }

    /// <summary>
    /// 添加点光源。
    /// </summary>
    /// <param name="color">color</param>
    /// <param name="point">point</param>
    public void AddPointLight(Color color, Point3D point)
    {
        PointLight light = new(color, new Point3D(0, 0, 0));

        _modelVisual.Children.Add(PackageModel3D(light, point));
    }

    /// <summary>
    /// 添加模型。
    /// </summary>
    /// <param name="baseModel">baseModel</param>
    public void AddModel(BaseModel baseModel)
    {
        _modelVisual.Children.Add(baseModel.GetModelVisual());
    }

    /// <summary>
    /// 将 Model3D 封装到 ModelVisual3D 中。
    /// </summary>
    /// <param name="model">model</param>
    /// <returns></returns>
    private static ModelVisual3D PackageModel3D(Model3D model)
    {
        ModelVisual3D modelVisual3D = new()
        {
            Content = model
        };

        return modelVisual3D;
    }

    /// <summary>
    /// 将 Model3D 封装到 ModelVisual3D 中。
    /// </summary>
    /// <param name="model">model</param>
    /// <returns></returns>
    private static ModelVisual3D PackageModel3D(Model3D model, Point3D point)
    {
        ModelVisual3D modelVisual3D = new()
        {
            Content = model,
            Transform = new TranslateTransform3D(point.X, point.Y, point.Z)
        };

        return modelVisual3D;
    }
}

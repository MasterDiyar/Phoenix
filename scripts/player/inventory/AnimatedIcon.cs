using Godot;

[GlobalClass]
public partial class AnimatedIcon : TextureRect
{
    [Signal] public delegate void ClickedEventHandler();
    
    [Export] IconResource Icon;

    private AtlasTexture _atlas;
    private double _timePassed;
    private int _currentFrame;

    public override void _Ready()
    {
        MouseFilter = MouseFilterEnum.Stop;
        
        if (Texture == null || Icon.HFrames <= 1) return;
        _atlas = new AtlasTexture { Atlas = (Texture2D)Texture };
        Texture = _atlas; 
        UpdateFrame();
    }

    public override void _Process(double delta)
    {
        if (_atlas == null || Icon.HFrames <= 1) return;

        _timePassed += delta;
        if (!(_timePassed >= 1f / Icon.FPS)) return;
        _timePassed -= 1f / Icon.FPS;
        _currentFrame = (_currentFrame + 1) % Icon.HFrames;
        UpdateFrame();
    }

    private void UpdateFrame()
    {
        float frameWidth = _atlas.Atlas.GetWidth() / (float)Icon.HFrames;
        float frameHeight = _atlas.Atlas.GetHeight();
        
        _atlas.Region = new Rect2(_currentFrame * frameWidth, 0, frameWidth, frameHeight);
    }

    public void Init(IconResource icon)
    {
        Icon = icon;
        _Ready();
    }
    
    public override void _GuiInput(InputEvent @event)
    {
        if (@event is not InputEventMouseButton mouseEvent || !mouseEvent.Pressed) return;
        switch (mouseEvent.ButtonIndex)
        {
            case MouseButton.Left:
                EmitSignal(SignalName.Clicked);
                break;
            case MouseButton.Right:
                break;
        }
    }
}
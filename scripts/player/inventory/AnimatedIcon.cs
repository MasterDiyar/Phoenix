using Godot;

namespace Dorozhniyi.scripts.player.inventory;

public partial class AnimatedIcon : TextureRect
{
    [Export] public int HFrames = 1; 
    [Export] public float Fps = 10f; 

    private AtlasTexture _atlas;
    private double _timePassed;
    private int _currentFrame;

    public override void _Ready()
    {
        if (Texture == null || HFrames <= 1) return;
        _atlas = new AtlasTexture { Atlas = (Texture2D)Texture };
        Texture = _atlas; 
        UpdateFrame();
    }

    public override void _Process(double delta)
    {
        if (_atlas == null || HFrames <= 1) return;

        _timePassed += delta;
        if (!(_timePassed >= 1f / Fps)) return;
        _timePassed -= 1f / Fps;
        _currentFrame = (_currentFrame + 1) % HFrames;
        UpdateFrame();
    }

    private void UpdateFrame()
    {
        float frameWidth = _atlas.Atlas.GetWidth() / (float)HFrames;
        float frameHeight = _atlas.Atlas.GetHeight();
        
        _atlas.Region = new Rect2(_currentFrame * frameWidth, 0, frameWidth, frameHeight);
    }
}
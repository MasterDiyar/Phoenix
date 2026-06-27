using Dorozhniyi.scripts.unit;
using Godot;

namespace Dorozhniyi.scripts.bullet;

public partial class Bullet : Area2D
{
    [Export] public BulletResource SelfResource;
    [Export] private Sprite2D _selfTexture;
    [Export] private Timer _selfTimer;
    
    public float Damage { get; private set; }
    public Entity Shooter { get; private set; }
    
    private float _currentSpeed;
    private bool _selfDamage;
    private bool _isAnimatable;
    private double _timePassed;
    private int _hFrames;
    private float _fpsDuration;

    public override void _Ready()
    {
        _currentSpeed = SelfResource.Speed;
        _isAnimatable = SelfResource.HasAnimates;
        _selfTexture.Texture = SelfResource.Icon;
        
        if (_isAnimatable)
        {
            _hFrames = SelfResource.HFrame;
            _selfTexture.Hframes = _hFrames;
            _fpsDuration = SelfResource.FPS > 0 ? 1f / SelfResource.FPS : 0;
        }

        _selfTimer.Start(SelfResource.LifeTime);
        _selfTimer.Timeout += QueueFree;
        BodyEntered += OnBodyEntered;
    }

    public void Init(float baseDamage, Entity shooter, bool canDamageSelf = false)
    {
        Damage = baseDamage * SelfResource.DamageMultiplier;
        Shooter = shooter;
        _selfDamage = canDamageSelf;
    }

    public override void _Process(double delta)
    {
        var dt = (float)delta;
        Position += Vector2.FromAngle(Rotation) * _currentSpeed * dt;
        _currentSpeed += SelfResource.Acceleration * dt;
        
        if (_isAnimatable && _fpsDuration > 0)
            ProcessAnimation(delta);
        
    }

    private void ProcessAnimation(double delta)
    {
        _timePassed += delta;
        if (_timePassed >= _fpsDuration) {
            _timePassed -= _fpsDuration;
            _selfTexture.Frame = (_selfTexture.Frame + 1) % _hFrames; 
        }
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is Entity ent)
        {
            if (ent == Shooter && !_selfDamage)
                return;
            
            // TODO: ent.TakeDamage(Damage);
            
            QueueFree(); 
        }
    }
}
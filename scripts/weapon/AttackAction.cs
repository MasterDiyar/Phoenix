using Dorozhniyi.scripts.item;
using Dorozhniyi.scripts.unit;
using Godot;

namespace Dorozhniyi.scripts.weapon;

public partial class AttackAction : ItemAction
{
    public enum AttackType
    {
        Swing, //60  degree
        Slash, //100 degree
        Stab,  //16  px
        Jab    //32  px
    }

    [Export] public AttackType Act;
    
    Tween _tween;
    Vector2 _currentPosition;
    float _currentRotation;
    
    
    public override void _Ready()
    {
        base._Ready();
        _currentRotation = _parent.Rotation;
        _currentPosition = _parent.Position;
    }


    protected override void ParentOnLeftClick(Vector2 fromPosition, Vector2 toPosition, Entity entity)
    {
        if (_onUse) return;
        _onUse = true;
        var damage = base._parent.ItemResource.Damage;
        switch (Act)
        {
            case AttackType.Swing:
                Swing(fromPosition, toPosition);
                break;
            default:
                GD.Print("ATTACKING or not implemented.");
                break;
        }
    }

    protected override void ParentOnRightClick(Vector2 fromPosition, Vector2 toPosition, Entity entity)
    {
        GD.Print("recharge");
    }

    private void Swing(Vector2 fromPos, Vector2 toPosition)
    {
        _currentRotation = _parent.Rotation;
        _currentPosition = _parent.Position;

        var useSpeed = _parent.ItemResource.UseSpeed;

        float swingDirection = (toPosition.X < fromPos.X) ? -1.0f : 1.0f;

        Vector2 direction = (toPosition - fromPos).Normalized();
        Vector2 thrustPosition = _currentPosition + direction * 16.0f;

        _tween = CreateTween();

        float targetRotation = _currentRotation + (Mathf.Pi * 0.33f * swingDirection);

        _tween.TweenProperty(_parent, "rotation", targetRotation, useSpeed * 0.75f);
        _tween.Parallel().TweenProperty(_parent, "position", thrustPosition, useSpeed * 0.75f);

        _tween.TweenProperty(_parent, "rotation", _currentRotation, useSpeed * 0.25f);
        _tween.Parallel().TweenProperty(_parent, "position", _currentPosition, useSpeed * 0.25f);

        _tween.Finished += () => _onUse = false;
    }
}
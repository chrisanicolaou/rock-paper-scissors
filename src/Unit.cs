using Godot;
using System;

public partial class Unit : Node2D
{
	[Export] public float Speed { get; set; } = 300;
	[Export] public UnitInfo UnitInfo { get; private set; }
	
	private Vector2 _screenSize;
	private Vector2 _startDirection;

	private Sprite2D _sprite;
	private RigidBody2D _rb;
	
	public override void _Ready()
	{
		_screenSize = GetViewportRect().Size;
		_startDirection = new Vector2
		{
			X = GD.Randf() * 2 - 1,
			Y = GD.Randf() * 2 - 1
		}.Normalized();
		_sprite = GetNode<Sprite2D>(nameof(Sprite2D));
		_rb = GetNode<RigidBody2D>(nameof(RigidBody2D));
	}

	public override void _Process(double delta)
	{
		Position += _startDirection * Speed * (float)delta;
		if (Position.X > _screenSize.X || Position.X < 0) _startDirection.X *= -1;
		if (Position.Y > _screenSize.Y || Position.Y < 0) _startDirection.Y *= -1;
	}

	public void MutateTo(UnitInfo unit)
	{
		_sprite.Texture = unit.Sprite;
		RemoveFromGroup(UnitInfo.GroupName);
		AddToGroup(unit.GroupName);
		_rb.CollisionMask = unit.MaskLayer;
		UnitInfo = unit;
	}

	private void OnBodyEntered(PhysicsBody2D body)
	{
		// if (body.IsInGroup(UnitInfo.LosesTo)) 
	}
}

using Godot;
using System;

public partial class Unit : Area2D
{
	[Export] public float Speed { get; set; } = 300;
	[Export] public UnitInfo UnitInfo { get; set; }
	public Vector2 Direction { get; private set; }

	private Global _global;
	
	private Vector2 _screenSize;

	private Sprite2D _sprite;
	
	public override void _Ready()
	{
		_global = GetNode<Global>("/root/Global");
		if (UnitInfo == null)
		{
			GD.PrintErr("Cannot instantiate Unit without a UnitInfo");
		}
		_screenSize = GetViewportRect().Size;
		Direction = new Vector2
		{
			X = GD.Randf() * 2 - 1,
			Y = GD.Randf() * 2 - 1
		}.Normalized();
		_sprite = GetNode<Sprite2D>(nameof(Sprite2D));
		MutateTo(UnitInfo);
	}

	public override void _Process(double delta)
	{
		Position += Direction * Speed * _global.SpeedMultiplier * (float)delta;
		if (Position.X > _screenSize.X || Position.X < 0) Direction = new Vector2(Direction.X * -1, Direction.Y);
		if (Position.Y > _screenSize.Y || Position.Y < 0) Direction = new Vector2(Direction.X, Direction.Y * -1);
	}

	public void MutateTo(UnitInfo unit)
	{
		GD.Print($"Unit: {unit}. CurrentUnitInfo: {UnitInfo}");
		_sprite.Texture = unit.Sprite;
		if (UnitInfo?.GroupName != null) RemoveFromGroup(UnitInfo.GroupName);
		AddToGroup(unit.GroupName);
		// _rb.CollisionMask = unit.MaskLayer;
		UnitInfo = unit;
	}

	private void OnAreaEntered(Area2D area)
	{
		if (area is not Unit collidingUnit) return;
		var dir = Direction;
		if (!IsSameSign(Direction.X, collidingUnit.Direction.X)) dir.X *= -1;
		if (!IsSameSign(Direction.Y, collidingUnit.Direction.Y)) dir.Y *= -1;
		Direction = dir;
		if (area.IsInGroup(UnitInfo.LosesTo)) MutateTo(collidingUnit.UnitInfo);
	}

	private bool IsSameSign(float x, float y)
	{
		return x > 0 && y > 0 || x < 0 && y < 0;
	}
}

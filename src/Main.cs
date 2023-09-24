using Godot;
using System;

public partial class Main : Node
{
	[Export] public PackedScene Unit { get; set; }
	[Export] public int Amount { get; set; }
	[Export] public Area2D PaperSpawnArea { get; set; }
	[Export] public Area2D RockSpawnArea { get; set; }
	[Export] public Area2D ScissorsSpawnArea { get; set; }
	[Export] public UnitInfo PaperInfo { get; set; }
	[Export] public UnitInfo ScissorsInfo { get; set; }
	[Export] public UnitInfo RockInfo { get; set; }

	public override void _Ready()
	{
		SpawnUnit(PaperInfo, PaperSpawnArea, Amount);
		SpawnUnit(ScissorsInfo, ScissorsSpawnArea, Amount);
		SpawnUnit(RockInfo, RockSpawnArea, Amount);
	}

	private void SpawnUnit(UnitInfo type, Area2D area, int amount)
	{
		var collisionShape = area.GetNode<CollisionShape2D>(nameof(CollisionShape2D));
		var collisionRect = collisionShape.Shape.GetRect();
		var width = collisionRect.End.X - collisionRect.Position.X;
		var height = collisionRect.End.Y - collisionRect.Position.Y;
		var collisionPos = collisionShape.GlobalPosition;
		var startPoint = new Vector2 { X = collisionPos.X - width / 2f, Y = collisionPos.Y - height / 2f };
		var endPoint = new Vector2 { X = collisionPos.X + width / 2f, Y = collisionPos.Y + height / 2f };
		for (var i = 0; i < amount; i++)
		{
			var spawnedNode = Unit.Instantiate();
			var nodeArea = spawnedNode as Area2D;
			var spawnedUnit = spawnedNode as Unit;
			GD.Print($"SpawnedUnit: {spawnedUnit}");
			spawnedUnit.UnitInfo = type;
			var random = new RandomNumberGenerator();
			var position = random.RandomVector(startPoint, endPoint);
			nodeArea.GlobalPosition = position;
			AddChild(spawnedNode);
		}
	}
}

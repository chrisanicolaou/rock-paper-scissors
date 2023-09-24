using Godot;

public static class RandomNumberGeneratorExtensions
{
    public static Vector2 RandomVector(this RandomNumberGenerator random, Vector2 start, Vector2 end)
    {
        var x = random.RandfRange(start.X, end.X);
        var y = random.RandfRange(start.Y, end.Y);
        return new Vector2 { X = x, Y = y };
    }
}
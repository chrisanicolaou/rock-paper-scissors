using Godot;

namespace RockPaperScissors;

/// <summary>
/// Wanted to see if extensions work.
/// <para></para>
/// They do, btw.
/// </summary>
public static class RandomNumberGeneratorExtensions
{
    public static Vector2 RandomVector(this RandomNumberGenerator random, Vector2 start, Vector2 end)
    {
        var x = random.RandfRange(start.X, end.X);
        var y = random.RandfRange(start.Y, end.Y);
        return new Vector2 { X = x, Y = y };
    }
}
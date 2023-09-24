using Godot;
using System;

namespace RockPaperScissors.Resources;

/// <summary>
/// <para>
/// A <a href="https://docs.godotengine.org/en/stable/tutorials/scripting/resources.html">resource</a> for storing information - including the sprite -
/// of the 3 battling units in the game (rock, paper, and scissors). 
/// </para>
/// <para></para>
/// <para>
/// Not fond of storing a "LosesTo" string but honestly i cba lol
/// </para>
/// <seealso cref="Unit"/>
/// <seealso cref="Main"/>
/// </summary>
public partial class UnitInfo : Resource
{
    [Export] public Texture2D Sprite { get; set; }
    [Export] public string GroupName { get; set; }
    [Export] public string LosesTo { get; set; }

    public override string ToString()
    {
        return $"GroupName: {GroupName}\nSprite: {Sprite}";
    }
}

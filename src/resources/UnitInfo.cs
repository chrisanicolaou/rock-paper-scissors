using Godot;
using System;

public partial class UnitInfo : Resource
{
    [Export] public Texture2D Sprite { get; set; }
    [Export] public string GroupName { get; set; }
    [Export] public uint MaskLayer { get; set; }
    [Export] public string LosesTo { get; set; }
}

using Godot;
using System;

namespace RockPaperScissors;

/// <summary>
/// <para>
/// An <a href="https://docs.godotengine.org/en/stable/tutorials/scripting/singletons_autoload.html">autoload node</a> (singleton) to hold game state - in this project, just a <see cref="SpeedMultiplier"/>.
/// </para>
/// <para></para>
/// There are cleaner ways to do this (a <a href="https://docs.godotengine.org/en/stable/tutorials/scripting/resources.html">resource</a>, for example) 
/// - but this gave me an opportunity to experiment with autoload nodes.
/// </summary>
public partial class Global : Node
{
	public int SpeedMultiplier { get; set; } = 1;
}

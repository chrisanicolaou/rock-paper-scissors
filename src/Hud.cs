using Godot;
using System;

namespace RockPaperScissors;

/// <summary>
/// <para>
/// Detects when the speed up button has been pressed, and updates the <see cref="Global.SpeedMultiplier">Global.SpeedMultiplier</see>.
/// </para>
/// <para>
/// A cleaner way to handle this would be to have the Hud emit a signal <see cref="OnButtonPressed"/>, and have a separate node manage the
/// logic. This would enforce single responsibility, and be more Godot-like.
/// </para>
/// <seealso cref="ButtonState"/>
/// <seealso cref="Global"/>
/// </summary>
public partial class Hud : CanvasLayer
{
	private Global _global;
	private ButtonState _state = ButtonState.Normal;
	private Button _button;

	public override void _Ready()
	{
		_global = GetNode<Global>("/root/Global");
		_button = GetNode<Button>(nameof(Button));
	}

	private void OnButtonPressed()
	{
		switch (_state)
		{
			case ButtonState.Normal:
				_button.Text = "Speed x2";
				_global.SpeedMultiplier = 2;
				_state = ButtonState.Fast;
				break;
			case ButtonState.Fast:
				_button.Text = "Speed x4";
				_global.SpeedMultiplier = 4;
				_state = ButtonState.Fastest;
				break;
			case ButtonState.Fastest:
				_button.Text = "Speed x16";
				_global.SpeedMultiplier = 16;
				_state = ButtonState.Fastester;
				break;
			case ButtonState.Fastester:
				_button.Text = "Speed x1";
				_global.SpeedMultiplier = 1;
				_state = ButtonState.Normal;
				break;
			default:
				throw new NotImplementedException($"Button state: {_state} not found.");
		}
	}
}

namespace RockPaperScissors;

/// <summary>
/// A simple enum creating hard-coded, tight-coupling between the UI and <see cref="Global.SpeedMultiplier"/>, for no reason other than I'm lazy.
/// <seealso cref="Global"/>
/// <seealso cref="Hud"/>
/// </summary>
public enum ButtonState
{
    Normal,
    Fast,
    Fastest,
    Fastester
}

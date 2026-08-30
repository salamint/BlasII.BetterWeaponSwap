using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap.Handlers;

/// <summary>
/// Handler for Embrujo, keeps Embrujo in the state it was before swapping
/// weapons.
/// If Embrujo was ignited, it will ignite it again when equipping it.
/// If Embrujo was not ignited, nothing will happen.
/// This keeps Embrujo ignited even when resting at a Prie Dieu.
/// </summary>
public class WhipCoreIgnitionModeSaver : WhipHandler
{
	/// <summary>
	/// Saves the value of the true skill state to be restored on demand.
	/// </summary>
	public static StatSaver CoreIgnitionModeSaver { get; } = new (CoreIgnitionMode);

    /// <summary>
	/// Boolean variable that saves the state in which Veredicto was before
	/// changing weapon.
	/// <code>
	/// true = ignited
	/// false = extinguished
	/// </code>
    /// </summary>
	private static bool IsIgnitedSavedState = false;

	/// <summary>
	/// Resets the ignited state to false (extinguished).
	/// </summary>
	public static void Reset()
	{
		IsIgnitedSavedState = false;
		CoreIgnitionModeSaver.Reset();
	}

    /// <summary>
	/// When Veredicto is equipped again, if it was in the ignited state before,
	/// this will reignite it. Otherwise, nothing will happen.
    /// </summary>
    public override void OnEquip()
    {
		CoreIgnitionModeSaver.Restore();
		if (CoreIgnitionModeFiller != null && IsIgnitedSavedState)
		{
			CoreIgnitionModeFiller.requestActivation = true;
		}
    }

    /// <summary>
	/// When Veredicto is unequipped, its current state is saved.
    /// </summary>
    public override void OnUnequip()
    {
		IsIgnitedSavedState = IsIgnited;
		CoreIgnitionModeSaver.Save();
	}
}


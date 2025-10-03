using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap;


/// <summary>
/// Handler for Veredicto, keeps Veredicto in the state it was before swapping
/// weapons.
/// If Veredicto was ignited, it will ignite it again when equipping it.
/// If Veredicto was not ignited, nothing will happen.
/// This keeps Veredicto ignited even when resting at a Prie Dieu.
/// </summary>
public class CenserIgnitionSaverHandler : CenserHandler
{
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
	/// </summary>
	public static void Reset()
	{
		IsIgnitedSavedState = false;
	}

    /// <summary>
	/// When Veredicto is equipped again, if it was in the ignited state before,
	/// this will reignite it. Otherwise, nothing will happen.
    /// </summary>
    protected override void OnEquip()
    {
		if (IsIgnitedSavedState && Igniter != null)
		{
			Igniter.IgniteCenser();
			Igniter.EnableIgnitionEffects();
			Igniter.Ignited = true;
			UIWeaponController.OnIgnitionStateChanged(true);
		}
    }

    /// <summary>
	/// When Veredicto is unequipped, its current state is saved.
    /// </summary>
    protected override void OnUnequip()
    {
		IsIgnitedSavedState = IsIgnited;
	}
}


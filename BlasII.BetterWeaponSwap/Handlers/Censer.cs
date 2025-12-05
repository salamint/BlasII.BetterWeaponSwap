using BlasII.Framework.WeaponEvents.Handlers;
using BlasII.ModdingAPI;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// </summary>
public class CenserIgnitionSaverHandler : CenserHandler
{
    /// <summary>
    /// </summary>
	private static bool IsIgnited = false;

    /// <summary>
    /// </summary>
	private static bool IsIgnitedSavedState = false;

    /// <summary>
    /// </summary>
    protected override void OnEquip()
    {
		if (IsIgnitedSavedState)
		{
			if (Igniter != null)
			{
				Igniter.IgniteCenser();
				Igniter.EnableIgnitionEffects();
				Igniter.Ignited = true;
				UIWeaponController.OnIgnitionStateChanged(true);
			}
		}
    }

    /// <summary>
    /// </summary>
    protected override void OnUnequip()
    {
		IsIgnitedSavedState = IsIgnited;
	}

	/// <summary>
	/// </summary>
    protected override void OnIgnited()
    {
		IsIgnited = true;
    }

    /// <summary>
    /// </summary>
    protected override void OnExtinguished()
    {
		IsIgnited = false;
    }
}


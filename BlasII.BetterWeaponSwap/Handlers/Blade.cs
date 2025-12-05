using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// Handles events from Ruego al Alba.
/// This handler's role is to save Ruego al Alba's berserk mode value
/// after swapping to another weapon.
/// </summary>
public class BladeBerserkModeSaver : BladeHandler
{
	/// <summary>
	/// Attribute that saves the current berserk mode value to be restored
	/// when switching back to Ruego al Alba.
	/// </summary>
	private static int BerserkModeValueSaved = 0;

	/// <summary>
	/// Resets the berserk mode value to 0.
	/// </summary>
	public static void Reset()
	{
		BerserkModeValueSaved = 0;
	}

    /// <summary>
	/// Saves the current berserk mode value when swapping from Ruego al Alba to
	/// another weapon.
    /// </summary>
	public override void OnEquip()
	{
		CurrentBerserkModeValue = BerserkModeValueSaved;
	}

    /// <summary>
	/// Restores the saved berserk mode value when swapping from another weapon
	/// back to Ruego al Alba.
    /// </summary>
	public override void OnUnequip()
	{
		BerserkModeValueSaved = CurrentBerserkModeValue;
	}
}

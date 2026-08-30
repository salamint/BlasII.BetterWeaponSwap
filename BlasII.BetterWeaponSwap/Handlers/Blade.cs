using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap.Handlers;

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
	public static StatSaver BerserkModeSaver { get; } = new (BerserkMode);

    /// <summary>
	/// Saves the current berserk mode value when swapping from Ruego al Alba to
	/// another weapon.
    /// </summary>
	public override void OnEquip()
	{
		BerserkModeSaver.Restore();
	}

    /// <summary>
	/// Restores the saved berserk mode value when swapping from another weapon
	/// back to Ruego al Alba.
    /// </summary>
	public override void OnUnequip()
	{
		BerserkModeSaver.Save();
	}
}

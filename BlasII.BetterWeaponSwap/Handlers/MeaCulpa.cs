using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap.Handlers;

/// <summary>
/// Handles events from the Mea Culpa.
/// This handler's role is to save the Mea Culpa's berserk mode value
/// after swapping to another weapon.
/// </summary>
public class MeaCulpaBerserkModeSaver : MeaCulpaHandler
{
	/// <summary>
	/// Attribute that saves the current berserk mode value to be restored
	/// when switching back to Mea Culpa.
	/// </summary>
	public static StatSaver BerserkMode = new ("MCBerserkMode");

    /// <summary>
	/// Saves the current berserk mode value when swapping from Mea Culpa to
	/// another weapon.
    /// </summary>
	public override void OnEquip()
	{
		BerserkMode.Restore();
	}

    /// <summary>
	/// Restores the saved berserk mode value when swapping from another weapon
	/// back to Mea Culpa.
    /// </summary>
	public override void OnUnequip()
	{
		BerserkMode.Save();
	}
}

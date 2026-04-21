using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap.Handlers;

/// <summary>
/// Handles the events from Sarmiento y Centella.
/// This handler's role is to save the charge of Sarmiento y Centella's
/// indicators after swapping to another weapon.
/// </summary>
public class RapierTrueSkillSaverHandler : RapierHandler
{
	/// <summary>
	/// Saves the value of the true skill state to be restored on demand.
	/// </summary>
	public static StatSaver TrueSkill = new ("TrueSkill");

	/// <summary>
	/// Restores the state of Sarmiento y Centella's indicators by reapplying
	/// the bonus that gave each saved attack object.
	/// </summary>
	public override void OnEquip()
	{
		TrueSkill.Restore();
	}

    /// <summary>
	/// Restores the saved berserk mode value when swapping from another weapon
	/// back to Mea Culpa.
    /// </summary>
	public override void OnUnequip()
	{
		TrueSkill.Save();
	}
}


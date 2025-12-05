using BlasII.Framework.WeaponEvents.Handlers;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// </summary>
public class BladeBerserkModeSaver : BladeHandler
{
	/// <summary>
	/// </summary>
	private static int BerserkModeValueSaved = 0;

    /// <summary>
    /// </summary>
	protected override void OnEquip()
	{
		CurrentBerserkModeValue = BerserkModeValueSaved;
	}

    /// <summary>
    /// </summary>
	protected override void OnUnequip()
	{
		BerserkModeValueSaved = CurrentBerserkModeValue;
	}
}

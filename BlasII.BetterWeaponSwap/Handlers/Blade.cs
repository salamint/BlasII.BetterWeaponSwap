using BlasII.Framework.WeaponEvents.Events;

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
	public static void Reset()
	{
		BerserkModeValueSaved = 0;
	}

    /// <summary>
    /// </summary>
	public override void OnEquip()
	{
		CurrentBerserkModeValue = BerserkModeValueSaved;
	}

    /// <summary>
    /// </summary>
	public override void OnUnequip()
	{
		BerserkModeValueSaved = CurrentBerserkModeValue;
	}
}

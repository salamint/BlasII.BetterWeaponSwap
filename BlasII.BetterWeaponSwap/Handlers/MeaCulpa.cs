using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// </summary>
public class MeaCulpaBerserkModeSaver : MeaCulpaHandler
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

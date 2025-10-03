using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// </summary>
public class WeaponReseter : WeaponHandler
{
	/// <summary>
	/// </summary>
	protected override void OnRestAtPrieDieu()
	{
		CenserIgnitionSaverHandler.Reset();
		RapierTrueSkillSaverHandler.Reset();
		BladeBerserkModeSaver.Reset();
		MeaCulpaBerserkModeSaver.Reset();
	}
}

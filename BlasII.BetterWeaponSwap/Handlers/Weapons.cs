using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// </summary>
public class WeaponReseter : WeaponHandler
{
	/// <summary>
	/// </summary>
	public override void OnRestAtPrieDieu()
	{
		CenserIgnitionSaverHandler.Reset();
		RapierTrueSkillSaverHandler.Reset();
		BladeBerserkModeSaver.Reset();
		MeaCulpaBerserkModeSaver.Reset();
	}
}

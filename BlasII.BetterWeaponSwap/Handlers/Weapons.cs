using BlasII.Framework.WeaponEvents.Events;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// The handleer's role is to reset every saved weapon state when the player
/// rests at a Prie Dieu.
/// </summary>
public class WeaponReseter : WeaponHandler
{
	/// <summary>
	/// When the player rests at a Prie Dieu, this methods calls the Reset
	/// method of every handler.
	/// </summary>
	public override void OnRestAtPrieDieu()
	{
		CenserIgnitionSaverHandler.Reset();
		RapierTrueSkillSaverHandler.Reset();
		BladeBerserkModeSaver.Reset();
		MeaCulpaBerserkModeSaver.Reset();
	}
}

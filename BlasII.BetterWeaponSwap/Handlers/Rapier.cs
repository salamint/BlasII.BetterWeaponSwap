using BlasII.Framework.WeaponEvents.Handlers;
using Il2CppTGK.Game.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.BetterWeaponSwap;

public class RapierTrueSkillSaverHandler : RapierHandler
{
	/// <summary>
	/// </summary>
	protected override void OnEquip(RapierTrueSkillFiller filler)
	{
		foreach (var attack in Main.BetterWeaponSwap.RapierAttacks)
		{
			Main.BetterWeaponSwap.ApplyBonus(filler, attack);
		}
	}

	/// <summary>
	/// </summary>
	protected override void OnAttack(AttackInfo attack, bool isHit)
	{
		Main.BetterWeaponSwap.RapierAttacks.Add(attack);
	}

	/// <summary>
	/// </summary>
	protected override void OnHitReceived(AttackInfo hit)
	{
		Main.BetterWeaponSwap.RapierAttacks.Clear();
	}
}


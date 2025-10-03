using BlasII.Framework.WeaponEvents.Events;
using Il2CppTGK.Game.Components.Attack.Data;
using System.Collections.Generic;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// </summary>
public class RapierTrueSkillSaverHandler : RapierHandler
{
	/// <summary>
	/// </summary>
	private static readonly List<AttackInfo> Attacks = [];

	/// <summary>
	/// </summary>
	public static void Reset()
	{
		Attacks.Clear();
	}

	/// <summary>
	/// </summary>
	protected override void OnEquip()
	{
		if (TrueSkillFiller != null)
		{
			foreach (var attack in Attacks)
			{
				Main.BetterWeaponSwap.ApplyBonus(TrueSkillFiller, attack);
			}
		}
	}

	/// <summary>
	/// </summary>
	protected override void OnAttackHit(AttackInfo attack)
	{
		Attacks.Add(attack);
	}

	/// <summary>
	/// </summary>
	protected override void OnHitReceived(AttackInfo hit)
	{
		Reset();
	}
}


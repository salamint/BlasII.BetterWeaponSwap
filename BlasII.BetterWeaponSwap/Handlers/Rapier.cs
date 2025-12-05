using BlasII.Framework.WeaponEvents.Events;
using Il2CppTGK.Game.Components.Attack.Data;
using System.Collections.Generic;

namespace BlasII.BetterWeaponSwap;

/// <summary>
/// Handles the events from Sarmiento y Centella.
/// This handler's role is to save the charge of Sarmiento y Centella's
/// indicators after swapping to another weapon.
/// </summary>
public class RapierTrueSkillSaverHandler : RapierHandler
{
	/// <summary>
	/// Attribute that stores the list of attacks that filled Sarmiento y
	/// Centella's indicators (most attacks that hits an enemy).
	/// </summary>
	private static readonly List<AttackInfo> Attacks = [];

	/// <summary>
	/// Empties the list of attacks that filled the indicators.
	/// </summary>
	public static void Reset()
	{
		Attacks.Clear();
	}

	/// <summary>
	/// Restores the state of Sarmiento y Centella's indicators by reapplying
	/// the bonus that gave each saved attack object.
	/// </summary>
	public override void OnEquip()
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
	/// Saves the attacks that have hit an enemy and adds them to the list of
	/// attacks that provided a bonus.
	/// </summary>
	public override void OnAttackHit(AttackInfo attack)
	{
		Attacks.Add(attack);
	}

	/// <summary>
	/// When the player receives a hit, this empties the list of attacks that
	/// charged the indicators.
	/// </summary>
	public override void OnHitReceived(AttackInfo hit)
	{
		Reset();
	}
}


using System.Collections.Generic;
using BlasII.ModdingAPI;
using Il2CppTGK.Game.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.BetterWeaponSwap;

public class BetterWeaponSwap : BlasIIMod
{
	internal readonly List<AttackInfo> RapierAttacks = [];

    internal BetterWeaponSwap() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

	/// <summary>
	/// </summary>
	protected internal void ApplyBonus(RapierTrueSkillFiller filler, AttackInfo attack)
	{
		int gain = 0;
		foreach (var bonus in filler.trueSkillAttackTable.trueSkillBonusTable)
		{
			if (bonus.AttackID.id == attack.attackID.id)
			{
				gain = bonus.Bonus;
			}
		}
		var stats = filler.playerStats.GetPtr();
		float y = stats.ApplyBonusAndUpgradesToValue(filler.tsGainStatID, gain);

		int currentValue = stats.GetCurrentValue(filler.trueSkillStatID, false);
		int maxValue = stats.GetMaxValue(filler.trueSkillStatID);
		gain = currentValue + (int)y;
		if (gain < 0)
		{
			gain = 0;
		}
		else if (maxValue < gain)
		{
			gain = maxValue;
		}
		stats.SetCurrentValue(filler.trueSkillStatID, gain);
		filler.consumptionCooldown = filler.consumptionLapseInSeconds;
	}

    protected override void OnInitialize()
    {
        // Perform initialization here
    }
}

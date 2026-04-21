namespace BlasII.BetterWeaponSwap;
using BlasII.ModdingAPI.Assets;
using Il2CppTGK.Game.Components.StatsSystem.Data;

/// <summary>
/// Saves the value of a stat when asked to, and restores it later.
/// Can also be reset to the default value whenever.
/// </summary>
public class StatSaver
{
	/// <summary>
	/// Name of the stat in the asset storage.
	/// </summary>
	public string StatName { get; private set; }

	/// <summary>
	/// Returns the stat ID corresponding to the stat name.
	/// </summary>
	public RangeStatID Stat { get => AssetStorage.RangeStats[StatName]; }

	/// <summary>
	/// Default value to which the stored value is reset to.
	/// </summary>
	public int DefaultValue { get; private set; }

	/// <summary>
	/// Currently saved value of the stat.
	/// </summary>
	public int StoredValue { get; private set; }

	/// <summary>
	/// Initializes a new stat saver from a stat name and a default value.
	/// </summary>
    public StatSaver(string statName, int defaultValue = 0)
	{
		StatName = statName;
		DefaultValue = defaultValue;
		Reset();
	}

	/// <summary>
	/// Resets the stored value to the default value.
	/// </summary>
	public void Reset()
	{
		StoredValue = DefaultValue;
	}

	/// <summary>
	/// Sets the value of the stat to the currently stored value.
	/// </summary>
	public void Restore()
	{
		AssetStorage.PlayerStats.SetCurrentValue(Stat, StoredValue);
	}

	/// <summary>
	/// Sets the stored value to the current value of the stat.
	/// </summary>
	public void Save()
	{
		StoredValue = AssetStorage.PlayerStats.GetCurrentValue(Stat);
	}
}


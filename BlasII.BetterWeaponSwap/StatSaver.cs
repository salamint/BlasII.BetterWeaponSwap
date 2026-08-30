namespace BlasII.BetterWeaponSwap;

using BlasII.Framework.WeaponEvents;

/// <summary>
/// Saves the value of a stat when asked to, and restores it later.
/// Can also be reset to the default value whenever.
/// </summary>
public class StatSaver
{
	/// <summary>
	/// The stat proxy object used to edit the stat.
	/// </summary>
	public RangeStatProxy StatProxy { get; init; }

	/// <summary>
	/// Default value to which the stored value is reset to.
	/// </summary>
	public int DefaultValue { get; private set; }

	/// <summary>
	/// Currently saved value of the stat.
	/// </summary>
	public int SavedValue { get; private set; }

	/// <summary>
	/// Initializes a new stat saver from a stat name and a default value.
	/// </summary>
    public StatSaver(RangeStatProxy statProxy, int defaultValue = 0)
	{
		StatProxy = statProxy;
		DefaultValue = defaultValue;
		Reset();
	}

	/// <summary>
	/// Resets the stored value to the default value.
	/// </summary>
	public void Reset()
	{
		SavedValue = DefaultValue;
	}

	/// <summary>
	/// Sets the value of the stat to the currently stored value.
	/// </summary>
	public void Restore()
	{
		StatProxy.Value = SavedValue;
	}

	/// <summary>
	/// Sets the stored value to the current value of the stat.
	/// </summary>
	public void Save()
	{
		SavedValue = StatProxy.Value;
	}
}


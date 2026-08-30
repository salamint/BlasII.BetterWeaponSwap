using MelonLoader;

namespace BlasII.BetterWeaponSwap;

internal class Main : MelonMod
{
#nullable disable
    public static BetterWeaponSwap BetterWeaponSwap { get; private set; }
#nullable enable

    public override void OnLateInitializeMelon()
    {
        BetterWeaponSwap = new BetterWeaponSwap();
    }
}

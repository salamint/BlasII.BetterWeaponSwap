using MelonLoader;

namespace BlasII.BetterWeaponSwap;

internal class Main : MelonMod
{
    public static BetterWeaponSwap BetterWeaponSwap { get; private set; }

    public override void OnLateInitializeMelon()
    {
        BetterWeaponSwap = new BetterWeaponSwap();
    }
}
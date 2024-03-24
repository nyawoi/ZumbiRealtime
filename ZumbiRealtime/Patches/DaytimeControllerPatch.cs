using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.ZumbiRealtime.Patches;

[HarmonyPatch(typeof(DaytimeController))]
public static class DaytimeControllerPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(DaytimeController.Init))]
    public static void ExtendDayLength(DaytimeController __instance)
    {
        // Set day length to match realtime day length (24 hours)
        __instance.dayDurationInMinutes = 60 * 24;
    }
}

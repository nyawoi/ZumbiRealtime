using System;
using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.ZumbiRealtime.Patches;

[HarmonyPatch(typeof(ZBMain))]
public static class ZBMainPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(ZBMain.OnEnteredMap))]
    public static void SetCurrentTime()
    {
        // Only set DaytimeController's `curTime` field on the server
        // Clients will automatically synchronize with host's current time upon joining match
        if (!MultiplayerController.instance.IsServer()) return;
        
        // Cache DateTime.Now for repeated calls to it
        var now = DateTime.Now;
        // Get percentage for how much of an hour has elapsed
        var fullHourPercentage =
            // sum up amount of seconds elapsed in current hour
            (now.Minute * 60 + now.Second)
            // divide sum by amount of seconds per hour (3600)
            / 3600f
            // divide by 100 to retrieve 0-1 percentage
            / 100f;
        
        // Combine the current hour with the percentage of elapsed hour
        // The `curTime` field ranges from 0 to 24, for every hour in an in-game day
        // The numbers after the decimal point are a percentage indicating how much of the hour has passed
        // For example: 10.5 would be equivalent to 10:30, as only half of the hour has elapsed
        DaytimeController.instance.curTime = now.Hour + fullHourPercentage;
    }
}

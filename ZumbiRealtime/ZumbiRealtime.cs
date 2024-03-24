using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.ZumbiRealtime;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class ZumbiRealtime : BaseUnityPlugin
{
    public const string PluginGUID = "AetharNet.Mods.ZumbiBlocks2.ZumbiRealtime";
    public const string PluginAuthor = "awoi";
    public const string PluginName = "ZumbiRealtime";
    public const string PluginVersion = "0.1.0";
    
    private void Awake()
    {
        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
    }
}

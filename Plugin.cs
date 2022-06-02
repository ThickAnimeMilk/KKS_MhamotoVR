using BepInEx;

namespace KKS_MhamotoVR
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "CUM.KKS_MhamotoVR";
        public const string PLUGIN_VERSION = "0.1.0";
        public const string PLUGIN_NAME = "MhamotoVR";
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");

            var harmony = new HarmonyLib.Harmony(PLUGIN_GUID);
            harmony.PatchAll(typeof(Hooks));
        }
    }
}

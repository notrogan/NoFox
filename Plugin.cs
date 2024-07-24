using BepInEx;
using BepInEx.Logging;
using NoFox.Patches;
using HarmonyLib;

namespace NoFox
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class NoFoxBase : BaseUnityPlugin
    {
        private const string modGUID = "rogan.NoFox";
        private const string modName = "No Fox";
        private const string modVersion = "1.0.4";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static NoFoxBase Instance;

        internal static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("NoFox Started!");

            harmony.PatchAll(typeof(NoFoxBase));
            harmony.PatchAll(typeof(StartRoundPatch));
            harmony.PatchAll(typeof(FoxSpawnPatch));
        }
    }
}

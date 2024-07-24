using HarmonyLib;
using System.Collections.Generic;

namespace NoFox.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class FoxSpawnPatch
    {
        [HarmonyPatch("LoadNewLevelWait")]
        [HarmonyPostfix]
        static void foxSpawnPatch(ref SelectableLevel ___currentLevel)
        {
            List<SpawnableEnemyWithRarity> outsideEnemies = ___currentLevel.OutsideEnemies;

            NoFoxBase.mls.LogInfo(outsideEnemies);

            SpawnableEnemyWithRarity wolf = null;
            foreach (SpawnableEnemyWithRarity item in outsideEnemies)
            {
                if (item.enemyType.enemyName == "BushWolf")
                {
                    wolf = item;
                }
            }
            if (wolf != null)
            {
                outsideEnemies.Remove(wolf);
            }
        }
    }
}

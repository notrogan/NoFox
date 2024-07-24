using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Unity.Netcode;

namespace NoFox.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    public class StartRoundPatch
    {
        [HarmonyPatch(typeof(StartOfRound), "SetPlanetsMold")]
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> setMoldPatch(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = instructions.ToList();
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i + 1].opcode == OpCodes.Call && list[i + 1].operand == AccessTools.Method(typeof(NetworkBehaviour), "get_IsServer"))
                {
                    list.RemoveRange(i, 3);
                    break;
                }
            }
            return list;
        }
    }
}
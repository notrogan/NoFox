using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace NoFox.Patches
{
    [HarmonyPatch(typeof(TimeOfDay))]
    public class TimeDayPatch
    {
        [HarmonyPatch(typeof(TimeOfDay), "OnDayChanged")]
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> dayChangePatch(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = instructions.ToList();
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i + 1].opcode == OpCodes.Callvirt && list[i + 1].operand == AccessTools.Method(typeof(StartOfRound), "SetPlanetsMold"))
                {
                    list.RemoveRange(i, 2);
                    break;
                }
            }
            return list;
        }
    }
}
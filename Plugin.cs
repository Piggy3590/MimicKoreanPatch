using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Mimics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimicKoreanPatch
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class MimicKoreanPatchModBase : BaseUnityPlugin
    {
        private const string modGUID = "Piggy3590.MimicKoreanPatch";
        private const string modName = "MimicKoreanPatch";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static MimicKoreanPatchModBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Mimic Korean Patch is loaded");

            harmony.PatchAll(typeof(MimicKoreanPatchModBase));
            harmony.PatchAll(typeof(StartOfRoundPatch));
        }
    }
}

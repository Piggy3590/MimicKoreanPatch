using BepInEx.Logging;
using DunGen;
using GameNetcodeStuff;
using HarmonyLib;
using Mimics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MimicKoreanPatch
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void Update_Postfix()
        {
            MimicDoor[] mimicDoors = UnityEngine.Object.FindObjectsOfType<MimicDoor>();
            foreach (MimicDoor mimicDoor in mimicDoors)
            {
                if (mimicDoor.interactTrigger != null)
                {
                    mimicDoor.interactTrigger.hoverTip = "나가기 : [LMB]";
                    mimicDoor.interactTrigger.holdTip = "나가기 : [LMB]";
                }
                else
                {
                    Debug.LogError(mimicDoor.name + " doesnt have InteractTrigger");
                }
            }
        }
    }
}


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
        public static float spawnDelayTimer = 0;
        [HarmonyPostfix]
        [HarmonyPatch("LateUpdate")]
        private static void LateUpdate_Postfix()
        {
            spawnDelayTimer += Time.deltaTime;
            if (spawnDelayTimer > 5)
            {
                MimicDoor[] mimicDoors = UnityEngine.Object.FindObjectsOfType<MimicDoor>();
                foreach (MimicDoor mimicDoor in mimicDoors)
                {
                    if (mimicDoor.interactTrigger != null)
                    {
                        if (mimicDoor.interactTrigger.hoverTip == "Feed : [LMB]") { mimicDoor.interactTrigger.hoverTip = "먹히기 : [LMB]"; }
                        if (mimicDoor.interactTrigger.holdTip == "Feed : [LMB]") { mimicDoor.interactTrigger.holdTip = "먹히기 : [LMB]"; }
                        if (mimicDoor.interactTrigger.hoverTip == "Exit : [LMB]") { mimicDoor.interactTrigger.hoverTip = "나가기 : [LMB]"; }
                        if (mimicDoor.interactTrigger.holdTip == "Exit : [LMB]") { mimicDoor.interactTrigger.holdTip = "나가기 : [LMB]"; }

                        if (mimicDoor.interactTrigger.holdTip == "DIE : [LMB]") { mimicDoor.interactTrigger.holdTip = "죽기 : [LMB]"; }
                        if (mimicDoor.interactTrigger.hoverTip == "Exit : [LMB]") { mimicDoor.interactTrigger.holdTip = "나가기 : [LMB]"; }
                    }
                    else
                    {
                        Debug.LogError(mimicDoor.name + " doesnt have InteractTrigger");
                    }
                }
            }
        }
    }
}


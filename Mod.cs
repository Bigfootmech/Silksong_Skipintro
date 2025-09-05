using BepInEx;
using HarmonyLib;
using System.Collections;
using UnityEngine;

namespace silksong_nointro_mod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Mod : BaseUnityPlugin
    {
        private const string modGUID = "com.bigfootmech.silksong.nointro";
        private const string modName = "Skip Intro";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        public void Awake()
        {
            harmony.PatchAll();
        }
    }
    
    [HarmonyPatch(typeof(StartManager), "Start")]
    public class AtStart
    {
        [HarmonyPostfix]
        static void Postfix(StartManager __instance, 
            IEnumerator __result, 
            ref AsyncOperation ___loadop) // , ref float ___FADE_SPEED
        {
            __instance.gameObject.GetComponent<Animator>().speed = 99999;
        }
    }
}


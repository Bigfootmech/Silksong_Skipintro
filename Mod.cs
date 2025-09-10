using BepInEx;
using HarmonyLib;
using System.Collections;
using UnityEngine;

namespace silksong_nointro_mod
{
    [BepInPlugin(modGUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Mod : BaseUnityPlugin
    {
        private const string modGUID = "com.bigfootmech.silksong.nointro";

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


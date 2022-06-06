using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using static KKS_MhamotoVR.MhamotoVR;

namespace KKS_MhamotoVR
{
    public static class Hooks
    {
		//This should hook to a method that loads as late as possible in the loading phase
		//Hooking method "MapSameObjectDisable" because: "Something that happens at the end of H scene loading, good enough place to hook" - DeathWeasel1337/Anon11
		//https://github.com/DeathWeasel1337/KK_Plugins/blob/master/KK_EyeShaking/KK.EyeShaking.Hooks.cs#L20
		[HarmonyPostfix]
		[HarmonyPatch(typeof(VRHScene), "MapSameObjectDisable")]
		public static void VRHSceneLoadPostfix(VRHScene __instance)
		{
			if (MhamotoObj != null)
				UnityEngine.Object.Destroy(MhamotoObj);

			MhamotoObj = __instance.gameObject.AddComponent<Mhamoto>();
			MhamotoObj.Init(__instance, (List<MotionIK>)Traverse.Create(__instance).Field("lstMotionIK").GetValue());
		}
	}
}
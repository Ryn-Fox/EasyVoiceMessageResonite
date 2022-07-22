using HarmonyLib;
using NeosModLoader;
using FrooxEngine.UIX;
using FrooxEngine;

namespace EasyVoiceMessage
{
    public class EasyVoiceMessage : NeosMod
    {
        public override string Name => "EasyVoiceMessage";
        public override string Author => "Sox";
        public override string Version => "1.0.0";
        public override string Link => "";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.Sox.EasyVoiceMessage");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(FriendsDialog))]
        class PatchEasyVoiceMessage
        {
            [HarmonyPostfix]
            [HarmonyPatch("OnAttach")]
            public static void PostFix(FriendsDialog __instance, SyncRef<Button> ____sendVoiceMessageButton)
            {
                ____sendVoiceMessageButton.Target.PassThroughVerticalMovement.Value = false;
                ____sendVoiceMessageButton.Target.PassThroughHorizontalMovement.Value = false;
            }
        }
    }
}
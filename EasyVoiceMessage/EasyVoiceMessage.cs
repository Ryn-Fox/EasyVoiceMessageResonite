using HarmonyLib;
using ResoniteModLoader;
using FrooxEngine.UIX;
using FrooxEngine;

namespace EasyVoiceMessage
{
    public class EasyVoiceMessage : ResoniteMod
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

        [HarmonyPatch(typeof(ContactsDialog))]
        class PatchEasyVoiceMessage
        {
            [HarmonyPostfix]
            [HarmonyPatch("OnAttach")]
            public static void PostFix(ContactsDialog __instance, SyncRef<Button> ____sendVoiceMessageButton)
            {
                ____sendVoiceMessageButton.Target.PassThroughVerticalMovement.Value = false;
                ____sendVoiceMessageButton.Target.PassThroughHorizontalMovement.Value = false;
            }
        }
    }
}
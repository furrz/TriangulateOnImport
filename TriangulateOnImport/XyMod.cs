using System;
using Assimp;
using HarmonyLib;
using NeosModLoader;
using FrooxEngine;
using FrooxEngine.UIX;

namespace NoTankControls
{
    public class XyMod : NeosMod
    {
        public override string Name => "TriangulateOnImport";
        public override string Author => "xyla";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/furrz/TriangulateOnImport";

        private static bool _first_trigger = false;

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("U-xyla.XyMod");
            harmony.PatchAll();
        }
        
        [HarmonyPatch(typeof(AssimpContext))]
        [HarmonyPatch("ImportFile")]
        class Patch2
        {
            private static void Prefix(string file, ref PostProcessSteps postProcessFlags)
            {
                postProcessFlags |= PostProcessSteps.Triangulate;
            }
        }
    }
}
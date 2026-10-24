using MelonLoader;
using Alta;
using CookingLib;
using UnityEngine;

[assembly: MelonInfo(typeof(CGNiksCustomLiquids.Core), "CGNiksCustomLiquids", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace CGNiksCustomLiquids
{
    using Hydrateordierate;
    internal class HydrateOrDiedrateCrossmod
    {
        internal static void RegisterThrists()
        {
            foreach (LibLiquid libLiquid in Core.thristLiquids)
            {
                HydrateApi.RegisterLiquidThirst(libLiquid.Definition.Hash, libLiquid.Spec.Thirst.Value);
            }
        }
    }

    public class Core : MelonMod
    {
        public static List<LibLiquid> thristLiquids = [];

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            CookingLib.Main.Setup += Setup;
        }

        private static void Setup()
        {
            LibLiquid mineralWater = Liquids.RegisterShared(
                35301,
                new LiquidSpec
                {
                    Id = "CGNiksCustomLiquids.MineralWater",
                    Name = "Mineral Water",
                    Look = "Water Liquid Visual Data",
                    Color = new Color(0.1f, 0.3f, 0.3f),
                    Effects = {
                        new EffectSpec { Effect = "Damage Indirect effect", Strength = 0.35f },
                        new EffectSpec { Effect = "Damage Protection Indirect effect", Strength = 1.35f },
                        new EffectSpec { Effect = "Speed Indirect effect", Strength = 0.35f }
                    },
                    Thirst = 60f
                }
            );

            Infusions.Register(
                new InfusionSpec
                {
                    Id = "CGNiksCustomLiquids.MineralWaterInfusion",
                    InputLiquids = ["Water"],
                    Item = "Stone",
                    OutputLiquid = "CGNik.MineralWater",
                    ConsumeItem = true
                }
            );

            thristLiquids.Add(mineralWater);

            if (MelonBase.FindMelon("Hydrate or Dierate", "TheRavenSeb") != null)
            {
                HydrateOrDiedrateCrossmod.RegisterThrists();
            }
        }
    }
}
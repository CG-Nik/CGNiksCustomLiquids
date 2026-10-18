using MelonLoader;
using Alta;
using CookingLib;
using UnityEngine;

[assembly: MelonInfo(typeof(CGNiksCustomLiquids.Core), "CGNiksCustomLiquids", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace CGNiksCustomLiquids
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            CookingLib.Main.Setup += Setup;
        }

        private static void Setup()
        {
            Liquids.RegisterShared(
                35301,
                new LiquidSpec
                {
                    Id = "CGNik.MineralWater",
                    Name = "Mineral Water",
                    Look = "Water Liquid Visual Data",
                    Color = new Color(0.1f, 0.3f, 0.3f),
                    Effects = {
                        new EffectSpec { Effect = "Damage Indirect effect", Strength = 0.35f },
                        new EffectSpec { Effect = "Damage Protection Indirect effect", Strength = 0.35f },
                        new EffectSpec { Effect = "Speed Indirect effect", Strength = 0.35f }
                    }
                }
            );

            Infusions.Register(
                new InfusionSpec
                {
                    Id = "CGNik.MineralWaterInfusion",
                    InputLiquids = ["Water"],
                    Item = "Stone",
                    OutputLiquid = "CGNik.MineralWater",
                    ConsumeItem = true
                }
            );
        }
    }
}
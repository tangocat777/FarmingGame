using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Helpers
{
    namespace Project1.Helpers
    {
        public static class PlantConfig
        {
            public enum PlantTypes
            {
                Carrot,
                Tomato,
                Wheat,
                NotAPlant,
                DoesNotExist
            }

            public enum GrowthStage
            {
                Stage1,
                Stage2,
                Stage3
            }

            public struct PlantDetails
            {
                public PlantTypes plantType;
                public GrowthStage growthStage;
                public int daysWatered;

                public PlantDetails(PlantTypes plantType, GrowthStage growthStage = GrowthStage.Stage1, int daysWatered = 0)
                {
                    this.plantType = plantType;
                    this.growthStage = growthStage;
                    this.daysWatered = daysWatered;
                }
            }

            public static readonly Dictionary<PlantTypes, Vector2I> AtlasCoordsForSeed = new()
            {
                { PlantTypes.Tomato, new Vector2I(9, 5) }
            };

            public static readonly Dictionary<Vector2I, PlantDetails> PlantLookup = new()
        {
            { new  Vector2I(2, 2), new PlantDetails{ plantType =PlantTypes.Wheat, growthStage = GrowthStage.Stage1 } },
            { new Vector2I(-1, -1), new PlantDetails{ plantType =PlantTypes.DoesNotExist, growthStage = GrowthStage.Stage1 } }
        };
        }
    }

}

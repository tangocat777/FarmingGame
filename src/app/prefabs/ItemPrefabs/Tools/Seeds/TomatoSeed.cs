using Godot;
using Project1.src.app.Items;
using static Project1.Helpers.Project1.Helpers.PlantConfig;

namespace Project1.src.app.prefabs.ItemPrefabs.Tools.Seeds
{
    public class TomatoSeed : Seed
    {
        public override Texture2D Texture
        {
            get
            {
                    return ResourceLoader.Load<Texture2D>("res://src/app/prefabs/PlantResources/tomato_seed.tres");
            }
        }
        public override SeedType seedType { get => SeedType.Tomato; }

        public override string Name => "Tomato Seed";
    }
}

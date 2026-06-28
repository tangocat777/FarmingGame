using Godot;
using Project1.src.app.Items;
using static Project1.Helpers.Project1.Helpers.PlantConfig;

namespace Project1.src.app.prefabs.ItemPrefabs.Tools.Seeds
{
    public class Hoe : Tool
    {
        private Texture2D _texture = null;
        private int _level = 1;
        public override Texture2D Texture
        {
            get
            {
                if (_texture == null)
                {
                    _texture = ResourceLoader.Load<Texture2D>("res://src/app/prefabs/ItemResources/Tools/FarmingTools/Hoe.png");
                }
                return _texture;
            }
        }

        public override int level { get => _level; set => _level = value; }

    }
}

using Godot;
using System;
using Chickensoft.GodotNodeInterfaces;
using Project1.src.app.Helpers;
using static Project1.Helpers.Project1.Helpers.PlantConfig;
using System.Collections.Generic;
using Project1.src.app.player;

namespace Project1.src.app.LogicControllers
{
    public interface IPlantController
    {
        bool LoadPlantsForMap();

        bool PlantSeedAtGlobalCoords(Vector2I coords, PlantTypes plantType);

    }

    public class PlantController : IPlantController
    {
        private ITileMapLayer plantLayer;
        private ITileMapLayer soilLayer;
        private INode2D game;
        private IPlayer player;
        private Dictionary<(int, int), PlantDetails> plantsInMap = new Dictionary<(int, int), PlantDetails>();
        private const int plotSize = 144;
        private PackedScene prefabPlantScene = GD.Load<PackedScene>("res://src/app/prefabs/prefab_plant.tscn");


        public PlantController(ITileMapLayer plantLayer, ITileMapLayer soilLayer, INode2D game, IPlayer player)
        {
            this.plantLayer = plantLayer;
            this.soilLayer = soilLayer;
            this.game = game;
            this.player = player;
        }


        public bool LoadPlantsForMap()
        {
            throw new NotImplementedException();
        }

        public static Vector2I convertGlobalCoordsToControllerCoords(Vector2I globalCoords)
        {
            //TODO: test the setting of this value after implementing movement system
            return new Vector2I(globalCoords.X/plotSize, globalCoords.Y/plotSize);
        }

        public static Vector2I convertControllerCoordsToGlobalCoords(Vector2I coords)
        {
            //TODO: test the setting of this value after implementing movement system
            return new Vector2I(coords.X * plotSize, coords.Y * plotSize);
        }

        public bool PlantSeedAtGlobalCoords(Vector2I coords, PlantTypes plantType)
        {
            var controllerCoords = convertGlobalCoordsToControllerCoords(coords);
            var plantExists = plantsInMap.ContainsKey((controllerCoords.X, controllerCoords.Y));
			var locationSoil = soilLayer.ToLocal(coords);
			//var locationPlant = plantLayer.ToLocal(coords);
			Vector2I realSoil = soilLayer.LocalToMap(locationSoil);
			//Vector2I realPlant = plantLayer.LocalToMap(locationPlant);
			var soilData = soilLayer.GetCellAtlasCoords(realSoil);
			//var plantData = plantLayer.GetCellAtlasCoords(realPlant);
			SoilConfig.SoilLookup.TryGetValue(soilData, out var soilState);
            //PlantLookup.TryGetValue(plantData, out var plantState);
			//can plant seed
			if (soilState.Equals(SoilConfig.SoilStates.Tilled) && !plantExists)
			{
                PlantDetails newPlant = new PlantDetails(plantType);
                AtlasCoordsForSeed.TryGetValue(PlantTypes.Tomato, out Vector2I atlasToPlant);
                // TODO: old way of adding plants, remove once adding objects directly to scene works.
                //plantLayer.SetCell(realPlant, 0, atlasToPlant);
                plantsInMap.Add((controllerCoords.X, controllerCoords.Y), newPlant);
                var instancedScene = prefabPlantScene.Instantiate<PrefabPlant>();
                instancedScene.setPlayer(player);
                instancedScene.GlobalPosition = GetGlobalCoordsFromSoilLocation(realSoil);
                game.AddChild(instancedScene);
                return true;
			}
            return false;
        }

        private static Vector2I GetGlobalCoordsFromSoilLocation(Vector2I location)
        {

            return new Vector2I(location.X * plotSize, location.Y * plotSize);
        }
    }
}

using Godot;
using System;
using Chickensoft.GodotNodeInterfaces;
using Project1.src.app.Helpers;
using Project1.Helpers.Project1.Helpers;
using static Project1.Helpers.Project1.Helpers.PlantConfig;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Project1.src.app.LogicControllers
{
    public interface IPlantController
    {
        bool LoadPlantsForMap();

        bool PlantSeedAtGlobalCoords(Vector2I coords, PlantTypes plantType);

        Vector2I convertGlobalCoordsToControllerCoords(Vector2I globalCoords);
    }

    public class PlantController : IPlantController
    {
        private ITileMapLayer plantLayer;
        private ITileMapLayer soilLayer;
        private Dictionary<(int, int), PlantDetails> plantsInMap = new Dictionary<(int, int), PlantDetails>();
        private const int plotSize = 144;


        public PlantController(ITileMapLayer plantLayer, ITileMapLayer soilLayer)
        {
            this.plantLayer = plantLayer;
            this.soilLayer = soilLayer;
        }


        public bool LoadPlantsForMap()
        {
            throw new NotImplementedException();
        }

        public Vector2I convertGlobalCoordsToControllerCoords(Vector2I globalCoords)
        {
            //TODO: test the setting of this value after implementing movement system
            return new Vector2I(globalCoords.X/plotSize, globalCoords.Y/plotSize);
        }

        public bool PlantSeedAtGlobalCoords(Vector2I coords, PlantTypes plantType)
        {
            var controllerCoords = convertGlobalCoordsToControllerCoords(coords);
            var plantExists = plantsInMap.ContainsKey((controllerCoords.X, controllerCoords.Y));
			var locationSoil = soilLayer.ToLocal(coords);
			var locationPlant = plantLayer.ToLocal(coords);
			Vector2I realSoil = soilLayer.LocalToMap(locationSoil);
			Vector2I realPlant = plantLayer.LocalToMap(locationPlant);
			var soilData = soilLayer.GetCellAtlasCoords(realSoil);
			var plantData = plantLayer.GetCellAtlasCoords(realPlant);
			SoilConfig.SoilLookup.TryGetValue(soilData, out var soilState);
            PlantLookup.TryGetValue(plantData, out var plantState);
			//can plant seed
			if (soilState.Equals(SoilConfig.SoilStates.Tilled) && !plantExists)
			{
                PlantDetails newPlant = new PlantDetails(plantType);
                AtlasCoordsForSeed.TryGetValue(PlantTypes.Tomato, out Vector2I atlasToPlant);
                plantLayer.SetCell(realPlant, 0, atlasToPlant);
                plantsInMap.Add((controllerCoords.X, controllerCoords.Y), newPlant);
                return true;
			}
            return false;
        }
    }
}

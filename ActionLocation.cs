using Godot;
using Project1.Helpers;
using Project1.Helpers.Project1.Helpers;
using System;
using System.Numerics;
using static Project1.Helpers.Project1.Helpers.PlantConfig;

public partial class ActionLocation : Marker2D
{
	[Export]
	TileMapLayer plant;
	[Export]
	TileMapLayer soil;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (Input.IsKeyPressed(Key.F))
        {
			var locationSoil = soil.ToLocal(GlobalPosition);
			var locationPlant = plant.ToLocal(GlobalPosition);
			Vector2I realSoil = soil.LocalToMap(locationSoil);
            Vector2I realPlant = plant.LocalToMap(locationPlant);
            var soilData = soil.GetCellAtlasCoords(realSoil);
			var plantData = plant.GetCellAtlasCoords(realPlant);
			SoilConfig.SoilLookup.TryGetValue(soilData, out var soilState);
			PlantLookup.TryGetValue(plantData, out var plantState);
			//can plant seed
			if(soilState.Equals(SoilConfig.SoilStates.Tilled) && plantState.plantType.Equals(PlantTypes.DoesNotExist))
			{
				AtlasCoordsForSeed.TryGetValue(PlantTypes.Tomato, out Vector2I atlasToPlant);
				plant.SetCell(realPlant, 0, atlasToPlant);
			}
        }
    }
}

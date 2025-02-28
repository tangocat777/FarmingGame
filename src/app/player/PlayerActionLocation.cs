using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;
using Project1.Helpers.Project1.Helpers;
using Project1.src.app.Helpers;
using Project1.src.app.LogicControllers;
using System;
using System.Numerics;
using static Project1.Helpers.Project1.Helpers.PlantConfig;

namespace Project1.src.app.player
{
	public interface IPlayerActionLocation
	{

	}
    [Meta(typeof(IAutoNode))]
    public partial class PlayerActionLocation : Marker2D, IPlayerActionLocation
	{
        //Note to self: have to apply this to every node that you want to use ChickenSoft's autoinject logic on
        public override void _Notification(int what) => this.Notify(what);
        [Dependency]
		public IPlantController plantController => this.DependOn<IPlantController>();

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (Input.IsKeyPressed(Key.F))
			{
                plantController.PlantSeedAtGlobalCoords(new Vector2I((int)GlobalPosition.X, (int)GlobalPosition.Y), PlantTypes.Tomato);
            }
		}
	}
}

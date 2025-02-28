using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;
using Project1.src.app.LogicControllers;
using Project1.src.app.player;

//This node will act as the main entry point and central logic controller for the game's components
public interface IFarmingGame : INode2D, IProvide<IPlantController>
{

}
[Meta(typeof(IAutoNode))]
public partial class FarmingGame : Node2D, IFarmingGame
{
    //Note to self: have to apply this to every node that you want to use ChickenSoft's autoinject logic on
    public override void _Notification(int what) => this.Notify(what);
    public IPlayer Player { get; set; } = default!;

    public IPlantController PlantController { get; set; } = default;

    IPlantController IProvide<IPlantController>.Value() => PlantController;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Player = GetNode<IPlayer>(new NodePath("./Player"));
        var plantLayer = GetNode<ITileMapLayer>(new NodePath("./Plant Layer"));
        var soilLayer = GetNode<ITileMapLayer>(new NodePath("./Soil Layer"));
        PlantController = new PlantController(plantLayer, soilLayer);
        this.Provide();
    }

    public void OnResolve()
    {
        this.Provide();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{   

    }
}

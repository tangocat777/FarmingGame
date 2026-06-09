using Chickensoft.GodotNodeInterfaces;
using Godot;
using Project1.Helpers.Project1.Helpers;
using Project1.src.app.player;
using static Project1.Helpers.Project1.Helpers.PlantConfig;

public partial class PrefabPlant : Node2D
{
	public PlantTypes type = PlantTypes.Tomato;
	public int successfulWaters = 0;
	private Sprite2D childSprite;
	private IPlayer player;

    private const int behindPlayerZIndex = 0;
	private const int beforePlayerZIndex = 2;
	private const int offsetPixels = -50;

    public PrefabPlant()
    {
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
    }

	public void setPlayer(IPlayer player)
	{
		this.player = player;
	}

	public void ProvideInitData(IPlayer player, int successfulWaters = 0, PlantTypes type = PlantTypes.Tomato)
	{
		setPlayer(player);
		this.successfulWaters = successfulWaters;
		this.type = type;
		init();
	}

	private void init()
	{
        childSprite = this.GetChild<Sprite2D>(0);
        childSprite.Texture = new Texture2D();
        childSprite.Texture = PlantConfig.LookupPlantTexture(type, successfulWaters);
        this.Visible = true;
    }

	public override void _Process(double delta)
	{
		var playerYOffset = player.GlobalPosition.Y + offsetPixels;
		if(this.GlobalPosition.Y > playerYOffset && this.ZIndex < beforePlayerZIndex)
		{
			this.ZIndex = beforePlayerZIndex;
		} else if(this.GlobalPosition.Y < playerYOffset && this.ZIndex > behindPlayerZIndex)
		{
			this.ZIndex = behindPlayerZIndex;
		}
	}
}

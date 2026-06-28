using Godot;
using Project1.src.app.logicControllers;
using Project1.src.app.player;
using System.Linq;

public interface IHudScene
{
    public IInventoryLayer GetInventoryLayer();
}

public partial class HudScene : CanvasLayer, IHudScene
{
	private IToolBarController toolBarController;
    private const string TOOLITEMSLOTNAMEPREFIX = "ToolPanel";
    private IInventoryLayer inventoryLayer;
	public override void _Ready()
	{
        var children = GetChildren();
        var toolItemSlotChildren = children.Where(c => c is CanvasItem && c.Name.ToString().Contains(TOOLITEMSLOTNAMEPREFIX)).Select(ci => (CanvasItem)ci).ToList();
        toolBarController = new ToolBarController();
        toolBarController.SetHudElements(toolItemSlotChildren);
        toolBarController.SetCurrentTool(0);
        inventoryLayer = GetNode<IInventoryLayer>(new NodePath("./InventoryLayer"));
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            switch (mouseEvent.ButtonIndex)
            {
                case MouseButton.WheelUp:
                    toolBarController.DecrementCurrentTool();
                    break;
                case MouseButton.WheelDown:
                    toolBarController.IncrementCurrentTool();
                    break;
            }
        }
    }

    IInventoryLayer IHudScene.GetInventoryLayer()
    {
        return inventoryLayer;
    }
}

using Godot;
using Project1.src.app.logicControllers;
using System.Linq;

public partial class HudScene : CanvasLayer
{
	private IToolBarController toolBarController;
    private const string TOOLITEMSLOTNAMEPREFIX = "ToolPanel";
	public override void _Ready()
	{
        var children = GetChildren();
        var toolItemSlotChildren = children.Where(c => c is CanvasItem && c.Name.ToString().Contains(TOOLITEMSLOTNAMEPREFIX)).Select(ci => (CanvasItem)ci).ToList();
        toolBarController = new ToolBarController();
        toolBarController.SetHudElements(toolItemSlotChildren);
        toolBarController.SetCurrentTool(0);
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
}

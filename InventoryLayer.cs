using Chickensoft.GodotNodeInterfaces;
using Godot;
using Project1.src.app.Constants;
using Project1.src.app.logicControllers;
using Project1.src.app.player;
using System;

public interface IInventoryLayer
{
	public void OpenInventory();
	public void CloseInventory();
}

public partial class InventoryLayer : CanvasLayer, IInventoryLayer
{
	private IInventoryController inventoryController;
	// Called when the node enters the scene tree for the first time.
	float inventoryXSpacing = 150;
	float inventoryYSpacing = 120;
	float initialXOffset = 150;
	float initialYOffset = 50;
	bool receivingInputs = false;
	public TextureRect DuplicateRect { get; set; } = default;
	public override void _Ready()
	{
        DuplicateRect = GetNode<TextureRect>(new NodePath("./DuplicateRect"));
        inventoryController = new InventoryController();
		this.Visible = false;
		SetupInventory();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
    }

	private void SetupInventory()
	{
		var columnCount = inventoryController.getDisplayColumns();
		var rowCount = inventoryController.getDisplayRows();
		for (int i = 0; i < columnCount; i++)
		{
			for (int j = 0; j < rowCount; j++)
			{
				var child = (TextureRect)DuplicateRect.Duplicate();
				child.Position = new Vector2(inventoryXSpacing*i+initialXOffset, inventoryYSpacing*j+initialYOffset);
				child.Visible = true;
				this.AddChild(child);
			}
		}
	}

    void IInventoryLayer.OpenInventory()
    {
		this.Visible = true;
		this.receivingInputs = true;
    }

    void IInventoryLayer.CloseInventory()
    {
		this.Visible = false;
		this.receivingInputs = false;
    }
}

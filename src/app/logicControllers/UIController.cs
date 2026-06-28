namespace Project1.src.app.logicControllers
{
    public enum ControlMode
    {
        Player,
        Inventory
    }
    public interface IUIController
    {
        public ControlMode GetCurrentMode();
        public void ProcessInventoryOpenAction();
    }

    //Controller that acts as a single source of truth for which part of the UI is currently active.
    public class UIController : IUIController
    {
        private ControlMode controlMode;
        private IInventoryLayer inventory;
        public UIController(IInventoryLayer inventoryLayer) {
            controlMode = ControlMode.Player;
            inventory = inventoryLayer;
        }

        public ControlMode GetCurrentMode()
        {
            return controlMode;
        }

        public void ProcessInventoryOpenAction()
        {
            var previousControlMode = controlMode;
            switch (controlMode)
            {
                case ControlMode.Player:
                    controlMode = ControlMode.Inventory;
                    break;
                case ControlMode.Inventory:
                    controlMode = ControlMode.Player;
                    break;
                default:
                    break;
            }
            if(previousControlMode != ControlMode.Inventory
                && controlMode == ControlMode.Inventory)
            {
                inventory.OpenInventory();
            }
            if (previousControlMode == ControlMode.Inventory
                && controlMode != ControlMode.Inventory)
            {
                inventory.CloseInventory();
            }
        }
    }
}

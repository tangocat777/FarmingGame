using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.src.app.logicControllers
{
    public interface IToolBarController
    {
        void SetCurrentTool(int index);
        void IncrementCurrentTool();
        void DecrementCurrentTool();
        void SetHudElements(IEnumerable<CanvasItem> toolBarSlots);
    }
    public class ToolBarController : IToolBarController
    {
        private List<CanvasItem> toolBarSlots;
        private int currentToolIndex = 0;
        private const float FOCUSEDALPHA = 1;
        private const float UNFOCUSEDALPHA = .39f;
        public void DecrementCurrentTool()
        {
            int previousIndex = currentToolIndex;
            if (currentToolIndex > 0)
            {
                currentToolIndex--;
            }
            else
            {
                currentToolIndex = toolBarSlots.Count - 1;
            }
            UpdateTransparency(previousIndex, currentToolIndex);
        }

        public void IncrementCurrentTool()
        {
            int previousIndex = currentToolIndex;
            if (currentToolIndex < toolBarSlots.Count - 1)
            {
                currentToolIndex++;
            }
            else
            {
                currentToolIndex = 0;
            }
            UpdateTransparency(previousIndex, currentToolIndex);
        }

        public void SetCurrentTool(int index)
        {
            int previousIndex = currentToolIndex;
            currentToolIndex = index;
            UpdateTransparency(previousIndex, currentToolIndex);
        }

        public void SetHudElements(IEnumerable<CanvasItem> toolBarSlots)
        {
            this.toolBarSlots = toolBarSlots.ToList();
            currentToolIndex = 0;
        }

        private void UpdateTransparency(int previousIndex, int newIndex)
        {
            toolBarSlots[previousIndex].Modulate = new Color(1, 1, 1, UNFOCUSEDALPHA);
            toolBarSlots[newIndex].Modulate = new Color(1, 1, 1, FOCUSEDALPHA);
        }
    }
}

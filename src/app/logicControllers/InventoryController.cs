using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.src.app.logicControllers
{
    public interface IInventoryController
    {
        public bool InsertItem(int index);
        public bool RemoveItem(int index);
        public int getDisplayColumns();
        public int getDisplayRows();
        public int getRemainingSlots();
        public int getTotalSlots();
    }
    public class InventoryController : IInventoryController
    {
        private int totalSlots = 24;
        private int numColumns = 6;
        private int numRows
        {
            get {
                return (totalSlots + numColumns - 1) / numColumns;
            }
        }

        public InventoryController() { }

        public int getDisplayColumns()
        {
            return numColumns;
        }

        public int getDisplayRows()
        {
            return numRows;
        }

        public int getRemainingSlots()
        {
            throw new NotImplementedException();
        }

        public int getTotalSlots()
        {
            throw new NotImplementedException();
        }

        public bool InsertItem(int index)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(int index)
        {
            throw new NotImplementedException();
        }
    }
}

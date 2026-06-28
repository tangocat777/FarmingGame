using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.src.app.Items
{
    public interface IItem
    {
        public string Name { get; }
        public Texture2D Texture { get; }
        public bool hasQuantity { get; }
        public int quantity { get; set; }

    }
    public class Item
    {
        public virtual string Name { get; } = "dummy item";
        public virtual Texture2D Texture { get; } = null;
        public virtual bool hasQuantity { get; } = false;
        public virtual int quantity { get; set; } = 0;

    }
}

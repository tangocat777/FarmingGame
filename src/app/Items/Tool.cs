using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.src.app.Items
{
    public enum ToolType
    {
        Hoe,
        WateringCan,
        Seed,
        None
    }
    public interface ITool
    {
        public ToolType toolType { get; }
        public int level { get; set; }
    }
    public class Tool : Item
    {
        public virtual ToolType toolType { get;} = ToolType.None;
        public virtual int level { get; set; } = 0;
    }
}

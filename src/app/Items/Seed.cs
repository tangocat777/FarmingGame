using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.src.app.Items
{
    public enum SeedType
    {
        Tomato,
        None
    }
    public interface ISeed
    {
        public SeedType seedType { get; }
    }
    public class Seed : Tool, ISeed
    {
        public virtual SeedType seedType { get; }
        public override ToolType toolType { get => ToolType.Seed; }
        public override int level { get => 1; }

        public override bool hasQuantity => true;
        public override int quantity { get => base.quantity; set => base.quantity = value; }
    }
}

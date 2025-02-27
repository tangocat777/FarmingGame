using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Helpers
{
    public static class SoilConfig
    {
        public enum SoilStates
        {
            Tilled,
            Valid,
            Invalid
        }

        public static readonly Dictionary<Vector2I, SoilStates> SoilLookup = new()
        {
            { new  Vector2I(2, 2), SoilStates.Tilled },
            { new Vector2I(-1, -1), SoilStates.Invalid }
        };
    }
}

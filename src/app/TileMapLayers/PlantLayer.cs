using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.src.app.TileMapLayers
{
    public partial class PlantLayer : TileMapLayer, ITileMapLayer
    {
        //Note to self: have to apply this to every node that you want to use ChickenSoft's autoinject logic on
        public override void _Notification(int what) => this.Notify(what);
    }
}

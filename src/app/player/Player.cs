using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Godot;
using System;

namespace Project1.src.app.player
{
    public interface IPlayer
    {

    }
    [Meta(typeof(IAutoNode))]
    public partial class Player : CharacterBody2D, IPlayer
    {
        //Note to self: have to apply this to every node that you want to use ChickenSoft's autoinject logic on
        public override void _Notification(int what) => this.Notify(what);

        public override void _PhysicsProcess(double delta)
        {
            //Marker location used to determine where an action is taken.
            Marker2D mySprite = GetNode<Marker2D>("Action Location");
        }
    }
}
using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Godot;
using System;

namespace Project1.src.app.player
{
    public interface IPlayer
    {
        public Vector2 GlobalPosition { get; }
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

        public override void _Process(double delta)
        {
            float speed = 5;
            if (Input.IsKeyPressed(Key.W))
            {
                this.Position += new Vector2(0, -speed);
            }
            if (Input.IsKeyPressed(Key.A))
            {
                this.Position += new Vector2(-speed, 0);
            }

            if (Input.IsKeyPressed(Key.S))
            {
                this.Position += new Vector2(0, speed);
            }

            if (Input.IsKeyPressed(Key.D))
            {
                this.Position += new Vector2(speed, 0);
            }
        }
    }
}
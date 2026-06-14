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
        private const float PLAYER_SPEED = 5;

        public override void _PhysicsProcess(double delta)
        {
            //Marker location used to determine where an action is taken.
            Marker2D mySprite = GetNode<Marker2D>("Action Location");
        }

        public override void _Process(double delta)
        {
            if (Input.IsKeyPressed(Key.W))
            {
                this.Position += new Vector2(0, -PLAYER_SPEED);
            }
            if (Input.IsKeyPressed(Key.A))
            {
                this.Position += new Vector2(-PLAYER_SPEED, 0);
            }

            if (Input.IsKeyPressed(Key.S))
            {
                this.Position += new Vector2(0, PLAYER_SPEED);
            }

            if (Input.IsKeyPressed(Key.D))
            {
                this.Position += new Vector2(PLAYER_SPEED, 0);
            }
        }
    }
}
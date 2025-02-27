using Godot;
using System;

public partial class Player : CharacterBody2D
{

	public override void _PhysicsProcess(double delta)
	{
        //Marker location used to determine where an action is taken.
        Marker2D mySprite = GetNode<Marker2D>("Action Location");
    }
}

using Godot;
using System;

public class Node2D : Godot.Node2D
{

    public static float DistanceTravelled;
    private PackedScene childscene;
    public override void _Ready()
    {
        childscene = GD.Load<PackedScene>("res://RigidBody2D.tscn");
       
    }
 
    public override void _Input(InputEvent @MousePress)
    {
       
       // Find how to use cursor as spawn location
       if (@MousePress is InputEventMouseButton mousepress)
        {   
            if (!mousepress.Pressed && mousepress.ButtonIndex ==(int)ButtonList.Left)
            {
                RigidBody2D Child = (RigidBody2D)childscene.Instance();
                this.AddChild(Child);
                Child.Position = mousepress.GlobalPosition;
            }
                            
 
        }
    }
}
 
 





using Godot;
using System;

public class Label2 : Label
{
    public override void _Process(float delta)
    {
        this.Text = "Linear Velocity="+GlobalVar.LinearVelocity;
    }
}

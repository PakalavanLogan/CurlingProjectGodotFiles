using Godot;
using System;

public class Label3 : Label
{
    public override void _Process(float delta)
    {
        this.Text = "AngularVelocity"+GlobalVar.AngularVelocity;
    }
}

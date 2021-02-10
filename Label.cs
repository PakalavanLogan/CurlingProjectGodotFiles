using Godot;
using System;

public class Label : Godot.Label
{
    
    public override void _Process(float delta)
    {
       this.Text = "Distance Travelled(Y)="+GlobalVar.DistanceTravelled;

    }
          
}

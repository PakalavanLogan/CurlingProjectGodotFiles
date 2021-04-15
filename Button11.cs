using Godot;
using System;

public class Button11 : Godot.Button
{
   
    public override void _Ready()
    {
        
    }

    public override void _Pressed()
    {
        GetTree().ChangeScene("res://control.tscn");
    }

        
    


}
using Godot;
using System;

public class buttonn13 : Button
{
    public override void _Ready()
    {
        
    }

    public override void _Pressed()
    {
        GetTree().ChangeScene("res://control.tscn");
    }

}

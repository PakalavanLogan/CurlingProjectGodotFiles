using Godot;
using System;

public class Button2 : Button
{
    public override void _Ready()
    {
        
    }

    public override void _Pressed()
    {
        GetTree().ChangeScene("res://Node2222D.tscn");
    }
}

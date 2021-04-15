using Godot;
using System;
 
public class Button : Godot.Button
{
   [Export] NodePath TorquePath;
   [Export] NodePath ImpulsePath;
   [Export] NodePath FrictionPath;
   [Export] NodePath Torque2Path;
   public SpinBox Torque;
   public SpinBox Impulse;
   public SpinBox Friction;
   public SpinBox Torque2;
    public override void _Ready()
    {
        Torque = GetNode<SpinBox>(TorquePath);
        Impulse = GetNode<SpinBox>(ImpulsePath);
        Friction = GetNode<SpinBox>(FrictionPath);
        Torque2 = GetNode<SpinBox>(Torque2Path);
    }
 
    public override void _Pressed()
    {
        GlobalVar.torque = (float)Torque.Value;
        GlobalVar.Impulse = -(float)Impulse.Value;
        GlobalVar.friction = (float)Friction.Value;
        GlobalVar.torque2 = (float)Torque2.Value;

        GetTree().ChangeScene("res://Node2D.tscn");
    }
 
        
    
 
 
}

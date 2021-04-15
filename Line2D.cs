using Godot;
using System;

public class Line2D : Godot.Line2D
{
    public Vector2 Point;
    public RigidBody2D Target;
    [Export] NodePath TargetPath;
    
    public override void _Ready()
    {
        Target = GetNode<RigidBody2D>(TargetPath);
    }

    public override void _Process(float delta)
    {
        this.GlobalPosition = (new Vector2(0,0));
        this.GlobalRotation = 0;
        Point = Target.GlobalPosition;
        AddPoint(Point);
    }
}

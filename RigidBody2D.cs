using Godot;
using System;
public class RigidBody2D : Godot.RigidBody2D
{
    public float TorForce = 20;
   public float CentralImpulseX = 0;
   public double CentralImpulseY = -0.452;
   public float FrictionX = 0;
   public double FrictionY = 2.492;
    public float torque = 2000;
    private Timer timer;
    public float lifetime = 10;
    private Vector2 OriginalPosition;
    public float DistanceTravelled;
    // 1Godot mass = 1000kg, 1pixel = 0.1m, 1pixel/s = 0.1m/s, 1Godot Force Unit = 100N, 1Godot Impulse = 100Kg*m/s


    public override void _Ready()
    {
        
    }

    
    public override void _UnhandledInput(InputEvent @MouseEvent)
    {
        if (@MouseEvent is InputEventMouseButton mouseclick)
        {
            //IMPULSE AND APPLIEDFORCE
            if (!mouseclick.Pressed && mouseclick.ButtonIndex ==(int)ButtonList.Right)
            {
                this.ApplyCentralImpulse(new Vector2(0,-250));
                           
            }

            var rotationDir = 0;
           //TORQUE
           if (!mouseclick.Pressed && mouseclick.ButtonIndex ==(int)ButtonList.Right)
           {
               rotationDir += 1;
               this.ApplyTorqueImpulse(rotationDir * torque);
           } 
            
            //LIFETIME
           if (!mouseclick.Pressed && mouseclick.ButtonIndex ==(int)ButtonList.Right)
           {
               timer = new Timer();
               this.AddChild(timer);
               timer.WaitTime = this.lifetime;
               timer.OneShot = true;
               timer.Connect("timeout",this,nameof(OnTimeToDie));
               timer.Start();
           }

           if (!mouseclick.Pressed && mouseclick.ButtonIndex ==(int)ButtonList.Right)
           {
               OriginalPosition = this.Position;
           }

        }
    }

    public void OnTimeToDie()
    {
        this.QueueFree();
    }

    public override void _PhysicsProcess(float delta)
    {
        if (this.LinearVelocity.y < 0)
        {
            this.AppliedForce = (new Vector2(5,50));
        }
            
        this.AppliedTorque = ((float)(-0.1*this.AngularVelocity));
        GlobalVar.LinearVelocity = this.LinearVelocity.y;
        GlobalVar.AngularVelocity = this.AngularVelocity;

        if (this.LinearVelocity.y == 0)
        {
            this.AppliedForce = (new Vector2(0,0));
            this.LinearVelocity = (new Vector2(0,0));
        }

        if (this.LinearVelocity.y > 0)
        {
            this.AppliedForce = (new Vector2(0,0));
            this.LinearVelocity = (new Vector2(0,0));
        }

        //CALCULATE DISTANCE TRAVELLED
        
        float DistanceTravelled = this.Position.DistanceTo(this.OriginalPosition);
        GlobalVar.DistanceTravelled = DistanceTravelled;
        
    }
}  
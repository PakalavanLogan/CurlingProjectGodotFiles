using Godot;
using System;

public class RigidBody22D : RigidBody2D
{
    private Timer timer;
    public float life = 1;
    public float friction;
    
    
    

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
                this.ApplyCentralImpulse(new Vector2(0,0));
                           
            }
            var rotationDir = 0;
            if (!mouseclick.Pressed && mouseclick.ButtonIndex ==(int)ButtonList.Right)
            {
                rotationDir += 1;
                this.ApplyTorqueImpulse(rotationDir * 0);
            }
        }
    

    }

    public override void _Process(float delta)
    {
        friction = GlobalVar.friction;
        
        if (this.LinearVelocity.y < 0)
        {
            this.AppliedForce = (new Vector2(0,(float)friction));
        }

        if (this.LinearVelocity.y > 0)
        {
            this.AppliedForce = (new Vector2(0,-(float)friction));
        }

        if (this.LinearVelocity.x > 0)
        {
            this.AppliedForce = (new Vector2(-(float)friction,0));
        }

        if (this.LinearVelocity.x < 0)
        {
            this.AppliedForce = (new Vector2((float)friction,0));
        }

       

        if (Input.IsKeyPressed((int)KeyList.W))
        {
            timer = new Timer();
            this.AddChild(timer);
            timer.WaitTime = this.life;
            timer.OneShot = true;
            timer.Connect("timeout",this,nameof(OnTimeTooDie));
            timer.Start();
        }
    }
    
    
    public void OnTimeTooDie()
    {
        this.QueueFree();
    }   

}

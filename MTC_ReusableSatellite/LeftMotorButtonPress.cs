using System;
using Assets;
using UnityEngine;

public class LeftMotorButtonPress : ButtonBehaviorBase<IMotorLeft>, IOnPositionChanged
{
    
    public void OnPositionEnter()
    {
        try
        {
            enableLight();
            GetMotor().TurnLeftOn();
        }catch(Exception e)
        {
            //eat ot
        }
    }

    /// <summary>
    /// need to turn off first?
    /// </summary>
    protected override void OnMotorStart()
    {
        GetMotor().TurnLeftOff();
    }


    public void OnPositionExit()
    {
        try
        {
            disableLight();
            GetMotor().TurnLeftOff();

        }catch(Exception e)
        {
            //eat it
        }
    }

    protected override IMotorLeft GetMotor()
    {
        return new MotorService();
    }
    
}

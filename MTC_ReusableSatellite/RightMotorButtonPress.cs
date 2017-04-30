using UnityEngine;
using System.Collections;
using System;
using Assets;

public class RightMotorButtonPress : ButtonBehaviorBase<IMotorRight>, IOnPositionChanged
{
    protected override IMotorRight GetMotor()
    {
        return new MotorService();
    }

    /// <summary>
    /// need to turn off first?
    /// </summary>
    protected override void OnMotorStart()
    {
        GetMotor().TurnRightOff();
    }

    public void OnPositionEnter()
    {
        Debug.Log("position entered");
        
        try
        {
            enableLight();
            GetMotor().TurnRightOn();

        }catch(Exception e)
        {
            //eat it
        }

    }

    public void OnPositionExit()
    {
        Debug.Log("position exit");
        try
        {
            disableLight();
            GetMotor().TurnRightOff();

        }catch(Exception e)
        {
            //eat it
        }
    }
    
}

using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothMotors : ButtonBehaviorBase<MotorService>, IOnPositionChanged
{
    public void OnPositionEnter()
    {
        try
        {
            enableLight();
            MotorService service = GetMotor();
            service.TurnRightOn();
            service.TurnLeftOn();
        }
        catch (Exception e)
        {
            //eat it
        }
    }

    public void OnPositionExit()
    {
        try
        {
            disableLight();
            MotorService service = GetMotor();
            service.TurnLeftOff();
            service.TurnRightOff();
        }
        catch (Exception e)
        {
            //eat it
        }
    }

    protected override MotorService GetMotor()
    {
        return new MotorService();
    }

    protected override void OnMotorStart()
    {
        MotorService service = GetMotor();
        service.TurnLeftOff();
        service.TurnRightOff();
    }
}

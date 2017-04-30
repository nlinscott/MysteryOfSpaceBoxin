using UnityEngine;
using System.Collections;

public abstract class ButtonBehaviorBase<T> : MonoBehaviour
{
    public Light Light;

    protected abstract T GetMotor();

    protected abstract void OnMotorStart();

    void Start()
    {
        disableLight();
        OnMotorStart();
    }

    protected void enableLight()
    {
        Light.enabled = true;
    }

    protected void disableLight()
    {
        Light.enabled = false;
    }
}

using UnityEngine;

public class NotifyPositionChanged : MonoBehaviour
{
    public GameObject Target;
    
    private bool entered = false;

    public float Distance = 0.050000f;
    
    void Update()
    {
        //are we close enough?
        if (IsNear())
        {
            //did we already notify this?
            if (!entered)
            {
                //nope, notify
                IOnPositionChanged positionChanged = gameObject.GetComponent<IOnPositionChanged>();
                if(positionChanged != null)
                {
                    positionChanged.OnPositionEnter();
                }
                //dont do it again until we leave
                entered = true;
            }
        }
        else
        {
            //if we were just in it and left,
            if (entered)
            {
                //notify we just left
                IOnPositionChanged positionChanged = gameObject.GetComponent<IOnPositionChanged>();
                if (positionChanged != null)
                {
                    positionChanged.OnPositionExit();
                }
                //dont call this back until we enter again
                entered = false;
            }
        }
    }

    /// <summary>
    /// Are we within 20 units?
    /// </summary>
    /// <returns></returns>
    private bool IsNear()
    {
        //float dx = (this.gameObject.transform.position.x - Target.transform.position.x);
        //float dy = (this.gameObject.transform.position.y - Target.transform.position.y);
        //float dz = (this.gameObject.transform.position.z - Target.transform.position.z);

        //Debug.Log(dx);
        //Debug.Log(dy);
        //Debug.Log(dz);

        float differnece = (gameObject.transform.position - Target.transform.position).magnitude;

        //Debug.Log(differnece < Distance);
       
        return differnece < Distance;
    }

}

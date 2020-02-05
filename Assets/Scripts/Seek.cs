using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek
{
    public Kinematic character;
    public GameObject target;

    float maxAcceleration = 100f;

    public bool flee = false;

    protected virtual Vector3 getTargetPosition()
    {
        return target.transform.position;
    }

    public virtual SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        
		result.linear = getTargetPosition() - character.transform.position;
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;
        return result;
    }
}

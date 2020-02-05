using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separate : MonoBehaviour
{
     public Kinematic character;
    public Kinematic[] targets;

    private float maxAcceleration = 4f;
    private float threshold = 4f;
    private float decayCoefficient = 2f;


    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        for (int i = 0; i < targets.Length; i++)
        {
           Vector3 direction = targets[i].transform.position - character.transform.position;
            float distance = direction.magnitude;

            if (distance < threshold)
            {
                //Get strength of repulsion using inverse square law\
                float strength = Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);

                direction = direction.normalized;
                result.linear += strength * direction;
            }
        }
        return result;
    }
}

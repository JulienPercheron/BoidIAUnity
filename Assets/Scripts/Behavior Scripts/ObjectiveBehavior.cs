using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Objective")]
public class ObjectiveBehavior : FlockBehavior
{



    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        

        return (agent.objective - (Vector2)agent.transform.position).normalized;
    }
}

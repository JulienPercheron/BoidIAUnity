using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Objective")]
public class ObjectiveBehavior : FlockBehavior
{
    static bool objectiveEnabled;



    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 objective = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            objectiveEnabled = !objectiveEnabled;
        }


        if (objectiveEnabled)
        {
            return (objective - (Vector2)agent.transform.position).normalized;
        }
        else
        {
            return Vector2.zero;
        }
    }
}

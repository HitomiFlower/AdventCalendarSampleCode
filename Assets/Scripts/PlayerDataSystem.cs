using System.Collections.Generic;
using UnityEngine;

public struct Axis
{
    public Vector3 value;
}

public struct CollisionRadius
{
    public float value;
}

public class PlayerDataSystem
{
    List<Axis> positions = new List<Axis>();
    List<CollisionRadius> radiusList = new List<CollisionRadius>();

    public PlayerDataSystem(List<Vector3> initPosition, List<float> initRadius)
    {
        for (int i = 0; i < initPosition.Count; i++)
        {
            positions.Add(new Axis {value = initPosition[i]});
            radiusList.Add(new CollisionRadius {value = initRadius[i]});
        }
    }

    public List<bool> IsCollision(Vector3 targetPosition, int length)
    {
        List<bool> collisionList = new List<bool>();
        for (int i = 0; i < length; i++)
        {
            var collision = Vector3.Distance(positions[i].value, targetPosition) < radiusList[i].value;
            if(collision)
                collisionList.Add(collision);
        }

        return collisionList;
    }
}

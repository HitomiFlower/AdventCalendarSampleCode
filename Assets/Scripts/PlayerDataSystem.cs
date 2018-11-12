using System.Collections.Generic;
using UnityEngine;

public struct Position
{
    public Vector3 value;
}

public struct CollisionRadius
{
    public float value;
}

public class PlayerDataSystem
{
    List<Position> positions = new List<Position>();
    List<CollisionRadius> radiusList = new List<CollisionRadius>();

    public PlayerDataSystem(List<Vector3> initPosition, List<float> initRadius)
    {
        for (int i = 0; i < initPosition.Count; i++)
        {
            positions.Add(new Position {value = initPosition[i]});
            radiusList.Add(new CollisionRadius {value = initRadius[i]});
        }
    }

    public bool[] IsCollision(Vector3 targetPosition, int length)
    {
        bool[] collisionList = new bool[length];
        for (int i = 0; i < length; i++)
        {
            collisionList[i] = Vector3.Distance(positions[i].value, targetPosition) < radiusList[i].value;
        }

        return collisionList;
    }
}

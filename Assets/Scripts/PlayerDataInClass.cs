using UnityEngine;


public class PlayerDataInClass
{
	public string name = "hoge";
	public float collisionRadius;
	public Vector3 position;

	public PlayerDataInClass(Vector3 position, float radius)
	{
		this.position = position;
		collisionRadius = radius;
	}

	public bool IsCollision(Vector3 targetPosition)
	{
		return Vector3.Distance(position, targetPosition) < collisionRadius;
	}
}



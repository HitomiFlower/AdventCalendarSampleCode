using UnityEngine;
	
namespace Classic
{
	public class Starter : MonoBehaviour
	{
		[SerializeField]
		private GameObject _prefab;

		[HideInInspector]
		public int count = 0;
		
		private void Start()
		{
			AddShip(Const.EnemyIncrement);
		}

		private void Update()
		{
			if (Input.GetKeyDown("space"))
			{
				AddShip(Const.EnemyIncrement);
			}
		}

		private void AddShip(int amount)
		{
			count += Const.EnemyIncrement;
			Debug.Log("Count:" + count);

			for (int i = 0; i < amount; i++)
			{
				float xVal = Random.Range(-500f, 500f);
				float zVal = Random.Range(-300f, 300f);
			
				Vector3 pos = new Vector3(xVal, 0f, zVal);
				Quaternion rot = Quaternion.Euler(0f, 180f, 0f);

				var obj = Instantiate(_prefab, pos, rot) as GameObject;
				Movement movement = obj.GetComponent<Movement>();
				movement.Speed = Random.Range(10f, 30f);
			}
		}
	}
}
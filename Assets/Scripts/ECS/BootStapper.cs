using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ECS;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class BootStapper : MonoBehaviour
{
    private EntityManager _entityManager;

    [SerializeField]
    private GameObject _shipPrefab;

    public quaternion angle;

    [HideInInspector]
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        _entityManager = World.Active.GetOrCreateManager<EntityManager>();
        AddShip(Const.EnemyIncrement);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AddShip(Const.EnemyIncrement);
        }
    }

    private void AddShip(int amount)
    {
        count += Const.EnemyIncrement;
        Debug.Log("Count: " + count);
        NativeArray<Entity> entities = new NativeArray<Entity>(amount, Allocator.Temp);
        _entityManager.Instantiate(_shipPrefab, entities);

        for (int i = 0; i < amount; i++)
        {
            float xVal = Random.Range(-500f, 500f);
            float zVal = Random.Range(-300f, 300f);
            _entityManager.SetComponentData(entities[i], new Position{ Value = new float3(xVal, 0f, zVal)});
            _entityManager.SetComponentData(entities[i], new Rotation {Value = angle});
            _entityManager.SetComponentData(entities[i], new Speed{Value = Random.Range(10f, 30f)});
        }
        
        entities.Dispose();
    }
}

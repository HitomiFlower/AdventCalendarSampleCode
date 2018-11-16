using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    private const int PlayerCount = 1000000;
    
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> initPositions = new List<Vector3>();
        List<float> initRadiuses = new List<float>();
        for (int i = 0; i < PlayerCount; i++)
        {
            initPositions.Add(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            initRadiuses.Add(Random.Range(0f, 0.3f));
        }
        Vector3 targetPosition = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        ClassExecute(initPositions, initRadiuses, targetPosition);
        
        StructExecute(initPositions, initRadiuses, targetPosition);
    }

    private void ClassExecute(List<Vector3> initPositions, List<float> initRadius, Vector3 targetPosition)
    {
        Stopwatch sw = new Stopwatch();
        
        List<PlayerDataInClass> playerDataInClasses = new List<PlayerDataInClass>(PlayerCount);

        for (int i = 0; i < PlayerCount; i++)
        {
            playerDataInClasses.Add(new PlayerDataInClass(initPositions[i], initRadius[i]));
        }
        
        sw.Start();
        int count = 0;
        foreach (var player in playerDataInClasses)
        {
            if (player.IsCollision(targetPosition))
            {
                count++;
            }
        }
        sw.Stop();
        Debug.Log($"Class execute finished! Count: {count}, time elapsed: {sw.Elapsed}");
    }

    private void StructExecute(List<Vector3> initPositions, List<float> initRadius, Vector3 targetPosition)
    {
        Stopwatch sw = new Stopwatch();
        
        PlayerDataSystem playerDataSystem = new PlayerDataSystem(initPositions, initRadius);
        
        sw.Start();
        var count = playerDataSystem.IsCollision(targetPosition, initPositions.Count);
        sw.Stop();
        Debug.Log($"Struct execute finished! Count: {count.Count}, time elapsed: {sw.Elapsed}");
    }
    
}

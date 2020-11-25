using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject obstacleObj;
    Vector3 startObstaclePosition = new Vector3(0, 0.5f, 0);
    int obstacleStep = 10;
    List<GameObject> obstaclecOnMap = new List<GameObject>();

    void GenerateObstacle(Vector3 lastObjPosition)
    {
        Vector3 newPositionToSpawn = new Vector3((int)Random.Range(-1.9f, 1.9f) * 3, lastObjPosition.y, lastObjPosition.z + obstacleStep);
        obstaclecOnMap.Add(Instantiate(obstacleObj, newPositionToSpawn, Quaternion.Euler(0, 0, 0)));
    }

    IEnumerator courtine;
    void Start()
    {
        GenerateObstacle(startObstaclePosition);
        for (int i = 0; i < 20; i++)
        {
            GenerateObstacle(obstaclecOnMap[obstaclecOnMap.Count - 1].transform.position);
        }

        courtine = WaitToSpawn(0.7f);
        StartCoroutine(courtine);
    }

    IEnumerator WaitToSpawn(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GenerateObstacle(obstaclecOnMap[obstaclecOnMap.Count - 1].transform.position);
            if (obstaclecOnMap.Count > 30)
            {
                Destroy(obstaclecOnMap[0]);
                obstaclecOnMap.Remove(obstaclecOnMap[0]);

            }
        }
    }

}

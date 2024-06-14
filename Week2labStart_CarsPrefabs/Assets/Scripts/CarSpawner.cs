using System;
using System.Linq;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    System.Random random = new System.Random();

    public GameObject[] carPrefabList;
    public float spawnInterval = 1;
    public int spawnedCarSpeed = 0;

    int spawnCount = 0;

    private void Start()
    {
        Debug.Assert(carPrefabList.Length != 0, "carSpawner Prefabs are not set");
    }

    void Update()
    {
        if (Time.time - (spawnCount * spawnInterval) >= spawnInterval)
        {
            GameObject carPrefab = carPrefabList[random.Next(carPrefabList.Length)];
            GameObject spawnedCar = Instantiate(carPrefab);
            spawnedCar.transform.SetLocalPositionAndRotation(transform.position, transform.rotation);
            if (spawnedCarSpeed>0)
                spawnedCar.GetComponent<SimpleCarMovement>().speed = spawnedCarSpeed;
            spawnCount++;
        }
    }
}

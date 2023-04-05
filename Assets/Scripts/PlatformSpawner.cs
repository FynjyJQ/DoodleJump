using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public PlatformsSet platformSet;
    void Start()
    {
        Vector2 SpawnPosition = new Vector2();

        for (int i = 0; i < 10; i++)
        {
            SpawnPosition.x = Random.Range(-Settings.xSpawnRange, Settings.xSpawnRange);
            SpawnPosition.y += Random.Range(Settings.ySpawnRangeStart, Settings.ySpawnRangeEnd);

            Instantiate(platformSet.gameObjects[Random.Range(0, platformSet.gameObjects.Count)], SpawnPosition, Quaternion.identity);
        }
    }
}

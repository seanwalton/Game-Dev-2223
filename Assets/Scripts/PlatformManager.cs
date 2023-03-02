using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private PlatformSpawner[] spawners;
    [SerializeField] private float spawnDelay;
 
    private int currentSpawner;

    private float nextPlatformIn;

    private void Start()
    {
        currentSpawner = -1;
        nextPlatformIn = 0f;
    }

    private void FixedUpdate()
    {
        nextPlatformIn -= Time.fixedDeltaTime;
        if (nextPlatformIn <= 0f)
        {
            SpawnNextPlatform();
            nextPlatformIn = spawnDelay;
        }
    }

    private void SpawnNextPlatform()
    {
        currentSpawner++;

        if (currentSpawner >= spawners.Length) currentSpawner = 0;

        spawners[currentSpawner].SpawnPlatform();
    }
}

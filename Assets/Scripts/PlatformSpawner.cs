using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float spawnDelay;
    private Transform tr;

    private void Awake()
    {
        tr = transform;
    }

    private void Start()
    {
        InvokeRepeating("SpawnPlatform", 0f, spawnDelay);
    }

    private void SpawnPlatform()
    {
        Instantiate(platformPrefab, tr.position, tr.rotation);
    }
}

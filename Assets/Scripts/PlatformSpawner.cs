using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    private Transform tr;

    private void Awake()
    {
        tr = transform;
    }

  

    public void SpawnPlatform()
    {
        Instantiate(platformPrefab, tr.position, tr.rotation);
    }
}

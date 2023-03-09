using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private static Queue<GameObject> pool = new Queue<GameObject>();

    [SerializeField] private GameObject platformPrefab;
    private Transform tr;

    private GameObject platform;

    private void Awake()
    {
        tr = transform;
    }

    public void SpawnPlatform()
    {
        platform = GetPlatform();
        platform.transform.SetPositionAndRotation(tr.position, tr.rotation);
        platform.SetActive(true);
        platform.SendMessage("OnRemoveFromPool", SendMessageOptions.DontRequireReceiver);
    }

    private GameObject GetPlatform()
    {
        if ((pool.Count == 0) || (pool.Peek().activeSelf == true))
        {
            platform = Instantiate(platformPrefab);
            pool.Enqueue(platform);
            return platform;
        }

        platform = pool.Dequeue();
        return platform;
    }
}

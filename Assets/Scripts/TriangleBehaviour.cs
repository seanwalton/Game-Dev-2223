using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;

    private Transform tr;
    private Vector3 pos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        pos = tr.position;
        pos.x += speed * Time.deltaTime;
        tr.position = pos;
    }
}

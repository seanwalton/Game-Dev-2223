using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatformBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2 velocity; 

    private Rigidbody2D rb2D;

    public Vector2 Velocity => velocity;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        OnRemoveFromPool();
    }

    public void OnRemoveFromPool()
    {
        rb2D.velocity = velocity;
    }
}

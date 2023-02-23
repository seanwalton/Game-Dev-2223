using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatformBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2 velocity; 

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2D.velocity = velocity;
    }
}

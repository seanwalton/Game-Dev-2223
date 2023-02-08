using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float walkSpeed;

    private Rigidbody2D rb2D;
    private Vector2 velocity = new Vector2();

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        velocity = rb2D.velocity;

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = walkSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -1f*walkSpeed;
        }

        rb2D.velocity = velocity;
    }

}

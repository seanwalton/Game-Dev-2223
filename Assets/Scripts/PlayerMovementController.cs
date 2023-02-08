using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float walkSpeed;

    private Rigidbody2D rb2D;
    private Vector2 velocity = new Vector2();
    private float currentSpeed = 0f;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        velocity = rb2D.velocity;

        currentSpeed = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed += walkSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed += -1f*walkSpeed;
        }

        velocity.x = currentSpeed;

        rb2D.velocity = velocity;
    }

}

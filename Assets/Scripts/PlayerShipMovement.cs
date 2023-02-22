using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float shipSpeed;

    private bool activeState = false;

    private Rigidbody2D rb2D;
    private Transform tr;
    private Vector2 newVelocity;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        tr = transform;
    }

    private void Update()
    {
        if (!activeState) return;

        if (Input.GetKey(KeyCode.D))
        {
            rb2D.rotation += rotationSpeed*Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2D.rotation -= rotationSpeed * Time.deltaTime;
        }

        newVelocity = shipSpeed * tr.up;
        rb2D.velocity = newVelocity;
    }

    public void ExitState(PlayerState oldState)
    {
        if (oldState == PlayerState.ASTEROIDS)
        {
            Debug.Log("Exit asteroids");
            activeState = false;
        }
    }

    public void EnterState(PlayerState newState)
    {
        if (newState == PlayerState.ASTEROIDS)
        {
            Debug.Log("Enter asteroids");
            rb2D.gravityScale = 0f;
            rb2D.constraints = RigidbodyConstraints2D.None;
            activeState = true;
        }
    }
}

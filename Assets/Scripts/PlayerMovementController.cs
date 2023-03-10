using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpSpeed;

    private Rigidbody2D rb2D;
    private Vector2 velocity = new Vector2();
    private float currentSpeed = 0f;
    private bool onGround = false;
    private bool activeState = false;
    private float rotation;
    private List<MovingPlatformBehaviour> movingPlatforms 
        = new List<MovingPlatformBehaviour>();

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!activeState) return;
        CheckRunSpeed();
        CheckJump();
    }

    public void LandedOnMovingPlatform(MovingPlatformBehaviour moving)
    {
        if (!movingPlatforms.Contains(moving)) movingPlatforms.Add(moving);
    }

    public void LeftMovingPlatform(MovingPlatformBehaviour moving)
    {
        if (movingPlatforms.Contains(moving)) movingPlatforms.Remove(moving);
    }

    public void OnGroundedChange(bool _onGround)
    {
        onGround = _onGround;
    }

    private void CheckJump()
    {
        velocity = rb2D.velocity;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (onGround) velocity.y = jumpSpeed;
        }
        rb2D.velocity = velocity;
    }

    private void CheckRunSpeed()
    {
        velocity = rb2D.velocity;
        currentSpeed = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed += walkSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed += -1f * walkSpeed;
        }

        velocity.x = currentSpeed;

        foreach (var item in movingPlatforms)
        {
            velocity.x += item.Velocity.x;
            velocity.y += item.Velocity.y;
        }

        rb2D.velocity = velocity;
    }

    public void ExitState(PlayerState oldState)
    {
        if (oldState == PlayerState.PLATFORMER)
        {
            Debug.Log("Exit platformer");
            rotation = rb2D.rotation;
            activeState = false;
        }
    }

    public void EnterState(PlayerState newState)
    {
        if (newState == PlayerState.PLATFORMER)
        {
            Debug.Log("Enter platformer");
            rb2D.SetRotation(rotation);
            activeState = true;
            rb2D.gravityScale = 1f;
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

}

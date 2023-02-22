using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    PLATFORMER = 0,
    ASTEROIDS = 1
}

public class PlayerStateBehaviour : MonoBehaviour
{

    [SerializeField] private PlayerState startingState;

    private PlayerState currentState;

    private void Start()
    {
        EnterPlayerState(startingState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (currentState)
            {
                case PlayerState.PLATFORMER:
                    ChangePlayerState(PlayerState.ASTEROIDS);
                    break;
                case PlayerState.ASTEROIDS:
                    ChangePlayerState(PlayerState.PLATFORMER);
                    break;
                default:
                    Debug.Log("Warning: Player state behaviour does have a valid state");
                    break;
            }
        }
    }

    private void ChangePlayerState(PlayerState newState)
    {
        SendMessage("ExitState", currentState, SendMessageOptions.DontRequireReceiver);
        EnterPlayerState(newState);
    }

    private void EnterPlayerState(PlayerState newState)
    {
        SendMessage("EnterState", newState, SendMessageOptions.DontRequireReceiver);
        currentState = newState;
    }
}

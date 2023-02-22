using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("I'm a spaceship");
    }

    public void ExitState(PlayerState oldState)
    {
        if (oldState == PlayerState.ASTEROIDS)
        {
            Debug.Log("Exit asteroids");
        }
    }

    public void EnterState(PlayerState newState)
    {
        if (newState == PlayerState.ASTEROIDS)
        {
            Debug.Log("Enter asteroids");
        }
    }
}

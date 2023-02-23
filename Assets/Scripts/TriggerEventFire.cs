using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventFire : MonoBehaviour
{
    public UnityEvent<bool> OnTriggerChange;
    public UnityEvent<MovingPlatformBehaviour> OnMovingPlatformEnter;
    public UnityEvent<MovingPlatformBehaviour> OnMovingPlatformExit;

    private MovingPlatformBehaviour moving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerChange?.Invoke(true);
        moving = collision.gameObject.GetComponentInParent<MovingPlatformBehaviour>();
        if (moving) OnMovingPlatformEnter?.Invoke(moving);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerChange?.Invoke(false);
        if (moving) OnMovingPlatformExit?.Invoke(moving);
    }
}

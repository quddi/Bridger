using System;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public event Action AnimationFinishedEvent;

    public void OnAnimationFinish()
    {
        if (AnimationFinishedEvent != null)
            AnimationFinishedEvent.Invoke();
    }
}

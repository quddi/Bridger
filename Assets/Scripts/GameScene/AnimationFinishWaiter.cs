using System;
using UnityEngine;

public class AnimationFinishWaiter : MonoBehaviour
{
    [SerializeField] private Car[] _cars;

    public event Action AnimationFinishEvent;

    private int _finishedAnimations = 0;

    private void OnCarAnimationFinished()
    {
        _finishedAnimations++;
        CheckAllAnimationFinish();
    }

    private void CheckAllAnimationFinish()
    {
        if (_finishedAnimations == _cars.Length)
        {
            AnimationFinishEvent.Invoke();
            ResetWaiting();
        }
    }

    private void ResetWaiting()
    {
        _finishedAnimations = 0;
    }

    private void OnEnable()
    {
        foreach (var car in _cars)
            car.AnimationFinishedEvent += OnCarAnimationFinished;
    }

    private void OnDisable()
    {
        foreach (var car in _cars)
            car.AnimationFinishedEvent -= OnCarAnimationFinished;
    }
}

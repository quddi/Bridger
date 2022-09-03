using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Car : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private int _allStatesCount;

    private Animator _animator;
    private int _animatorState;
    private const int AnimationStopParameter = -1;
    private const string AnimatorParameterName = "MovementNumber";

    public event Action CarArrivedEvent;
    public event Action CarStartsEvent;
    public event Action AnimationFinishedEvent;
    public event Action CollidedEvent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
        _animatorState = 0;
        MoveToStartPosition(_index);
    }

    private void MoveToStartPosition(int index)
    {
        _animator.SetInteger(AnimatorParameterName, index);
        _animatorState = index;
    }

    public void MoveOnce()
    {
        _animatorState = (_animatorState + 1) % _allStatesCount;
        _animator.SetInteger(AnimatorParameterName, _animatorState);
    }

    public void OnCarArrived()
    {
        CarArrivedEvent?.Invoke();
    }

    public void OnCarStarts()
    {
        CarStartsEvent?.Invoke();
    }

    public void OnAnimationFinished()
    {
        AnimationFinishedEvent?.Invoke();
    }

    public void StopAnimation()
    {
        _animator.SetInteger(AnimatorParameterName, AnimationStopParameter);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _animator.SetInteger(AnimatorParameterName, -1);
        if (collision.gameObject.GetComponent<BridgePart>() != null)
            CollidedEvent?.Invoke();
    }
}

using UnityEngine;
using System;

[RequireComponent(typeof(AnimationFinishWaiter))]
public class CarMover : MonoBehaviour
{
    [SerializeField] private Car[] _cars;
    [SerializeField] private Bridge _bridge;

    public event Action<TransportType> CarArrivedEvent;

    private bool _animationIsAlreadyActive = false;
    private AnimationFinishWaiter _animationFinishWaiter;

    private void Awake()
    {
        _animationFinishWaiter = GetComponent<AnimationFinishWaiter>();
    }

    private void OnBridgeMoved(BridgeUplift uplift)
    {
        if (uplift == BridgeUplift.Down)
            MoveCarsOnce();
    }

    private void MoveCarsOnce()
    {
        if(_animationIsAlreadyActive == false)
        {
            foreach (var car in _cars)
                car.MoveOnce();
            _animationIsAlreadyActive = true;
        }
    }

    private void OnAnimationFinished()
    {
        _animationIsAlreadyActive = false;
        CarArrivedEvent?.Invoke(TransportType.Car);
    }

    private void OnEnable()
    {
        _bridge.UpliftEvent += OnBridgeMoved;
        _animationFinishWaiter.AnimationFinishEvent += OnAnimationFinished;
    }

    private void OnDisable()
    {
        _bridge.UpliftEvent -= OnBridgeMoved;
        _animationFinishWaiter.AnimationFinishEvent += OnAnimationFinished;
    }
}

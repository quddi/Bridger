using System;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private BoatsContainer _boatsContainer;
    [SerializeField] private PlanesContainer _planesContainer;
    [SerializeField] private CarsContainer[] _carsContainers;
    [SerializeField] private Animator[] _animatorsToStop;

    [SerializeField] private Bridge _bridge;

    [SerializeField] private GameObject _finishUI;

    [SerializeField] private Rigidbody _bridgeRightPart;
    [SerializeField] private Rigidbody _bridgeLeftPart;

    public event Action GameFinishedAction;

    private void OnSomethingExploded()
    {
        FinishGame();
    }

    private void FinishGame()
    {
        if (GameFinishedAction != null)
            GameFinishedAction();

        StopAnimators();

        _bridgeLeftPart.isKinematic = true;
        _bridgeRightPart.isKinematic = true;

        _boatsContainer.enabled = false;
        _planesContainer.enabled = false;

        foreach (var car in _carsContainers)
            car.enabled = false;

        _finishUI.SetActive(true);
    }

    private void StopAnimators()
    {
        foreach (var animator in _animatorsToStop)
            animator.enabled = false;
    }

    private void OnEnable()
    {
        _bridge.BridgeExplosionEvent += OnSomethingExploded;
        _boatsContainer.BoatExplodedEvent += OnSomethingExploded;
        _planesContainer.PlaneExplodedEvent += OnSomethingExploded;

        foreach (var car in _carsContainers)
            car.CarExplodedEvent += OnSomethingExploded;
    }

    private void OnDisable()
    {
        _bridge.BridgeExplosionEvent -= OnSomethingExploded;
        _boatsContainer.BoatExplodedEvent -= OnSomethingExploded;
        _planesContainer.PlaneExplodedEvent -= OnSomethingExploded;

        foreach (var car in _carsContainers)
            car.CarExplodedEvent -= OnSomethingExploded;
    }
}

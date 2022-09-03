using System;
using UnityEngine;

[RequireComponent(typeof(Car))]
public class CarsContainer : VehiclesContainer
{
    private int _currentCar = 0;
    private Car _car;
    private CarExplosion _explosion;

    public event Action CarExplodedEvent;

    private void Awake()
    {
        _car = GetComponent<Car>();
        _explosion = GetComponent<CarExplosion>();
    }

    private void Start()
    {
        HideAll();
        ActivateRandomAvailable();
    }

    protected override void ActivateRandomAvailable()
    {
        Hide(_currentCar);
        _currentCar = UnityEngine.Random.Range(0, _vehicles.Length);
        Unhide(_currentCar);
    }

    private void OnCarArrived()
    {
        HideAll();
    }

    private void OnCarStarts()
    {
        ActivateRandomAvailable();
    }

    private void OnCarExploded()
    {
        CarExplodedEvent?.Invoke();
    }

    private void OnEnable()
    {
        _car.CarArrivedEvent += OnCarArrived;
        _car.CarStartsEvent += OnCarStarts;

        _explosion.ExplosionEvent += OnCarExploded;
    }

    private void OnDisable()
    {
        _car.CarArrivedEvent -= OnCarArrived;
        _car.CarStartsEvent -= OnCarStarts;

        _explosion.ExplosionEvent -= OnCarExploded;
    }
}


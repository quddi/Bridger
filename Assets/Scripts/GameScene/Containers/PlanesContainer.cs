using UnityEngine;
using System;

public class PlanesContainer : VehiclesContainer
{
    [SerializeField] private BoatsContainer _boatsContainer;
    [SerializeField] private Animator _animator;

    private int _currentPlaneIndex;
    private readonly string _animatorVarName = "PlayAnimation";

    public event Action PlaneExplodedEvent;

    protected override void ActivateRandomAvailable()
    {
        EnableRandomAvailable();
        _animator.SetBool(_animatorVarName, true);
    }

    private void EnableRandomAvailable()
    {
        Hide(_currentPlaneIndex);

        _currentPlaneIndex = UnityEngine.Random.Range(0, _vehicles.Length);

        Unhide(_currentPlaneIndex);
    }

    private void OnBoatStarted(TransportType transportType)
    {
        if (transportType == TransportType.ShortBoat)
            ActivateRandomAvailable();
    }

    public void OnPlaneArrived()
    {
        HideAll();
    }

    public void OnPlaneStarted()
    {
        _animator.SetBool(_animatorVarName, false);
    }

    public void OnPlaneExploded()
    {
        if (PlaneExplodedEvent != null)
            PlaneExplodedEvent.Invoke();

        _animator.SetTrigger("Fall");
    }

    private void OnEnable()
    {
        _boatsContainer.BoatStartedEvent += OnBoatStarted;

        foreach (var vehicle in _vehiclesExplosions)
            vehicle.ExplosionEvent += OnPlaneExploded;
    }

    private void OnDisable()
    {
        _boatsContainer.BoatStartedEvent -= OnBoatStarted;

        foreach (var vehicle in _vehiclesExplosions)
            vehicle.ExplosionEvent -= OnPlaneExploded;
    }
}

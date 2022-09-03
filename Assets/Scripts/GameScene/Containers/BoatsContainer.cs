using System;
using UnityEngine;

public class BoatsContainer : VehiclesContainer
{
    [Range(1, 2)]
    [SerializeField] private float _maxAnimationSpeed;

    private int _currentBoat = 0;
    private Animator _animator;

    public event Action<TransportType> BoatArrivedEvent;
    public event Action<TransportType> BoatStartedEvent;
    public event Action BoatExplodedEvent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        HideAll();
        ActivateRandomAvailable();
    }

    protected override void ActivateRandomAvailable()
    {
        EnableRandomAvailable();
        _animator.SetFloat("AnimationSpeed", UnityEngine.Random.Range(1, _maxAnimationSpeed));

        if (BoatStartedEvent != null)
            BoatStartedEvent.Invoke(_vehicles[_currentBoat].GetComponent<Tag>().TransportType);
    }

    private void EnableRandomAvailable()
    {
        _vehicles[_currentBoat].SetActive(false);

        _currentBoat = UnityEngine.Random.Range(0, _vehicles.Length);

        _vehicles[_currentBoat].SetActive(true);
    }

    public void OnBoatArrived()
    {
        ActivateRandomAvailable();
        BoatArrivedEvent.Invoke(TransportType.Boat);
    }
}

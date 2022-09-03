using System;
using UnityEngine;

public class CarExplosion : VehicleExplosion
{
    [SerializeField] private ParticleSystem _explosionParticles;

    private Car _car;

    public override event Action ExplosionEvent;

    private void Awake()
    {
        _car = GetComponent<Car>();
    }

    private void OnEnable()
    {
        _car.CollidedEvent += Explode;
    }

    private void OnDisable()
    {
        _car.CollidedEvent -= Explode;
    }

    protected override void Explode()
    {
        _explosionParticles.Play();
        ExplosionEvent?.Invoke();
    }

}

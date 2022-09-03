using System;
using UnityEngine;

public class PlaneExplosion : VehicleExplosion
{
    [SerializeField] private ParticleSystem _explosionParticles;

    public override event Action ExplosionEvent;

    protected override void Explode()
    {
        _explosionParticles.Play();

        ExplosionEvent?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}

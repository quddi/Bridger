using System;
using UnityEngine;

public class BridgeExplosion : MonoBehaviour
{
    [SerializeField] private Bridge _bridge;
    [SerializeField] private ParticleSystem _explosionParticleSystem;
    
    private void Explode()
    {
        _explosionParticleSystem.Play();
    }

    private void OnEnable()
    {
        _bridge.BridgeExplosionEvent += Explode;
    }

    private void OnDisable()
    {
        _bridge.BridgeExplosionEvent -= Explode;
    }
}

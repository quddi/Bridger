using UnityEngine;
using System;

public abstract class VehicleExplosion : MonoBehaviour
{
    [SerializeField] private VehiclesContainer _thisContainer;

    public abstract event Action ExplosionEvent;
    protected abstract void Explode();
}

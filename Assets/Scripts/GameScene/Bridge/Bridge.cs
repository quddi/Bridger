using System;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private BridgePart _leftPart, _rightPart;

    public event Action BridgeExplosionEvent;
    public event Action<BridgeUplift> UpliftEvent;

    private void OnBridgeCollision()
    {
        Explode();
    }

    private void OnPartUplift()
    {
        if (_leftPart.Uplift == _rightPart.Uplift)
            if  (UpliftEvent != null)
                UpliftEvent.Invoke(_leftPart.Uplift);
    }

    private void Explode()
    {
        if (BridgeExplosionEvent != null)
            BridgeExplosionEvent.Invoke();
    }

    private void OnEnable()
    {
        _leftPart.CollisionEvent += OnBridgeCollision;
        _rightPart.CollisionEvent += OnBridgeCollision;
        _leftPart.UpliftEvent += OnPartUplift;
        _rightPart.UpliftEvent += OnPartUplift;
    }

    private void OnDisable()
    {
        _leftPart.CollisionEvent -= OnBridgeCollision;
        _rightPart.CollisionEvent -= OnBridgeCollision;
        _leftPart.UpliftEvent += OnPartUplift;
        _rightPart.UpliftEvent += OnPartUplift;
    }
}

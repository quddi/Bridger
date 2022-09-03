using System;
using UnityEngine;

[RequireComponent(typeof(BridgePartRotation))]
public class BridgePart : MonoBehaviour
{
    private BridgePartRotation _partRotation;

    public event Action CollisionEvent;
    public event Action UpliftEvent;

    public BridgeUplift Uplift { get; private set; }

    private void Awake()
    {
        _partRotation = GetComponent<BridgePartRotation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Tag collisiongTag = collision.gameObject.GetComponent<Tag>();

        if (collisiongTag == null)
            return;

        if (collisiongTag.TransportType == TransportType.Boat ||
            collisiongTag.TransportType == TransportType.ShortBoat ||
            collisiongTag.TransportType == TransportType.Plane)
            CollisionEvent.Invoke();
    }

    private void OnThisPartMoved(BridgeUplift uplift)
    {
        if (Uplift == uplift) //bridges uplift didnt change
            return;

        Uplift = uplift;

        if (UpliftEvent != null)
            UpliftEvent.Invoke();
    }

    private void OnEnable()
    {
        _partRotation.RotationEvent += OnThisPartMoved;
    }

    private void OnDisable()
    {
        _partRotation.RotationEvent -= OnThisPartMoved;
    }
}

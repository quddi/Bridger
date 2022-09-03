using UnityEngine;
using System;

public class BridgePartRotation : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private const float SpringForce = 5000;

    public event Action<BridgeUplift> RotationEvent;

    public void AddTorque(int uplift)
    {
        BridgeUplift convertedUplift = (BridgeUplift)uplift;

        JointSpring spring = new JointSpring();

        spring.targetPosition = uplift;
        spring.spring = SpringForce;
        spring.damper = 100;

        _hingeJoint.useSpring = true;
        _hingeJoint.spring = spring;

        if (RotationEvent != null)
            RotationEvent.Invoke(convertedUplift);
    }
}

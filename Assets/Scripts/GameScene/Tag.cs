using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransportType
{
    ShortBoat,
    Boat,
    Car,
    Plane
}

public class Tag : MonoBehaviour
{
    [SerializeField]
    private TransportType _transportType;
    [SerializeField]
    private int _index;

    public TransportType TransportType { get { return _transportType; } }
    public int Index { get { return _index; } }

}

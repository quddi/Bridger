using UnityEngine;

public abstract class VehiclesContainer : MonoBehaviour
{
    [SerializeField] protected GameObject[] _vehicles;
    [SerializeField] protected VehicleExplosion[] _vehiclesExplosions;

    protected abstract void ActivateRandomAvailable();

    protected void Hide(int index)
    {
        _vehicles[index].SetActive(false);
    }

    protected void Unhide(int index)
    {
        _vehicles[index].SetActive(true);
    }

    protected void HideAll()
    {
        for (int i = 0; i < _vehicles.Length; i++)
            Hide(i);
    }
}

using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BoatsContainer _boatsContainer;
    [SerializeField] private CarMover _carMover;

    public event Action<int> ScoreUpdateAction;

    private int _score = 0;
    public int Score { get { return _score;} }

    private const int BoatArrivedBonusScore = 10;
    private const int PlaneArrivedBonusScore = 20;
    private const int CarArrivedBonusScore = 30;

    private void UpdateScore(int additionScore)
    {
        if (additionScore <= 0)
            throw new ArgumentException("Addition score on UpdateScore() was less or equal to 0.");

        _score += additionScore;
        ScoreUpdateAction(_score);
    }

    private void OnTransportArrived(TransportType transportType)
    {
        switch (transportType)
        {
            case TransportType.Boat:
                UpdateScore(BoatArrivedBonusScore);
                break;
            case TransportType.Plane:
                UpdateScore(PlaneArrivedBonusScore);
                break;
            case TransportType.Car:
                UpdateScore(CarArrivedBonusScore);
                break;
        }
    }

    private void OnEnable()
    {
        _boatsContainer.BoatArrivedEvent += OnTransportArrived;
        _carMover.CarArrivedEvent += OnTransportArrived;
    }

    private void OnDisable()
    {
        _boatsContainer.BoatArrivedEvent -= OnTransportArrived;
        _carMover.CarArrivedEvent -= OnTransportArrived;
    }
}

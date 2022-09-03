using UnityEngine;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private GameFinisher _gameFinisher;

    private void OnGameFinished()
    { 
        SaveScore();
    }

    private void SaveScore()
    {
        if (Serializer.GameData.BestScore > _scoreCounter.Score)
            Serializer.GameData.BestScore =  _scoreCounter.Score;

        Serializer.SaveData();
    }

    private void OnEnable()
    {
        _gameFinisher.GameFinishedAction += OnGameFinished;
    }

    private void OnDisable()
    {
        _gameFinisher.GameFinishedAction -= OnGameFinished;
    }
}

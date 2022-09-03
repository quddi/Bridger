using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreCounter _scoreCounter;

    void Start()
    {
        _scoreCounter.ScoreUpdateAction += OnScoreUpdate;
    }

    private void OnScoreUpdate(int score)
    {
        _scoreText.text = string.Format($"Score: {score}");
    }
}

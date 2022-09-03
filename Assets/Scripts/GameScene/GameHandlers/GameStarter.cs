using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private StartUI _startUI;
    [SerializeField] private GameObject _startUIBlock;
    [SerializeField] private BoatsContainer _boardContainer;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void Start()
    {
        DisableGame();
    }

    private void OnStartAnimationFinished()
    {
        DeactivateStartUI();
    }

    private void DeactivateStartUI()
    {
        _startUIBlock.SetActive(false);
        EnableGame();
    }

    private void EnableGame()
    {
        _boardContainer.enabled = true;
        _scoreCounter.enabled = true;
    }

    private void DisableGame()
    {
        _boardContainer.enabled = false;
        _scoreCounter.enabled = false;
    }

    private void OnEnable()
    {
        _startUI.AnimationFinishedEvent += OnStartAnimationFinished;
    }

    private void OnDisable()
    {
        _startUI.AnimationFinishedEvent -= OnStartAnimationFinished;
    }
}

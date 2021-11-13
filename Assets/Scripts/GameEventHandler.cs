using UnityEngine;

public class GameEventHandler : MonoBehaviour
{
    [SerializeField] private Snake _snake;
    [SerializeField] private SnakeMover _mover;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private RestartScreen _restartScreen;
    [SerializeField] private AppleSpawner _appleSpawner;
    [SerializeField] private GameScreen _gameScreen;

    private void OnEnable()
    {
        _snake.SnakeGrow += OnSnakeGrowUp;
        _snake.ScoreChanged += OnScoreChanged;
        _snake.SnakeDead += OnSnakeDead;
        _startScreen.StartButtonClick += OnStartButtonClick;
        _restartScreen.RestartButtonClick += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _snake.SnakeGrow -= OnSnakeGrowUp;
        _snake.ScoreChanged -= OnScoreChanged;
        _snake.SnakeDead -= OnSnakeDead;
        _startScreen.StartButtonClick -= OnStartButtonClick;
        _restartScreen.RestartButtonClick += OnRestartButtonClick;
    }

    private void Start()
    {
        _startScreen.Open();
        Time.timeScale = 0;
    }

    private void OnSnakeGrowUp()
    {
        _mover.AddTailBone();
    }

    private void OnScoreChanged()
    {
        _appleSpawner.ResetSpawner();
        _gameScreen.ShowScore(_snake.Score);
    }

    private void OnSnakeDead()
    {
        Time.timeScale = 0;
        _restartScreen.Open();
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        Time.timeScale = 1;
    }

    private void OnRestartButtonClick()
    {
        _restartScreen.Close();
        _mover.RemoveTailBone();
        _snake.ResetScore();
        Time.timeScale = 1;
    }
}

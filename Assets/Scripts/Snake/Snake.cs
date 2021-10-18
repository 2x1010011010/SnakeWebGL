using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{
    private int _score;

    public int Score => _score;

    public event UnityAction SnakeGrow;
    public event UnityAction ScoreChanged;
    public event UnityAction SnakeDead;

    private void Start()
    {
        _score = 0;
    }

    public void GrowUp(int value)
    {
        for (int i = 0; i < value; i++)
        {
            SnakeGrow?.Invoke();
            _score++; 
        }

        ScoreChanged?.Invoke();
    }

    public void Die()
    {
        SnakeDead?.Invoke();
    }
}

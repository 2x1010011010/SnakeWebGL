using UnityEngine;

[RequireComponent(typeof(Snake))]
public class SnakeCollisionHandler : MonoBehaviour
{
    private Snake _snake;

    private void Start()
    {
        _snake = GetComponent<Snake>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Apple>(out Apple apple))
            _snake.GrowUp(apple.Value);
        else
            _snake.Die();
    }
}

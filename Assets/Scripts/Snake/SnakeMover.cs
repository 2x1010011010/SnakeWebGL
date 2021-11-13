using System.Collections.Generic;
using UnityEngine;


public class SnakeMover : MonoBehaviour
{
    [SerializeField] private Transform _snakeHead;
    [SerializeField] private float _circleDiameter;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _tailPrefab;

    private MouseTracker _mouse;
    private Vector2 _movingDirection;
    private List<Transform> _snakeCircles = new List<Transform>();
    private List<Vector2> _nextPositions = new List<Vector2>();
    private Vector3 _startPosition;

    private void Start()
    {
        _mouse = GetComponent<MouseTracker>();
        _nextPositions.Add(_snakeHead.position);
        _startPosition = _snakeHead.position;
    }

    private void Update()
    {
        TurnToMouse();
        SnakeHeadMove();
        TailMovement();
    }

    private void TurnToMouse()
    {
        Vector2 snakeHeadPosition = _snakeHead.position;
        _movingDirection = _mouse.Position - snakeHeadPosition;
        transform.right = _movingDirection;
    }

    private void SnakeHeadMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, _mouse.Position, _speed * Time.deltaTime);
    }

    private void TailMovement()
    {
        float distance = ((Vector2)_snakeHead.position - _nextPositions[0]).magnitude;

        if (distance > _circleDiameter)
        {
            Vector2 direction = ((Vector2)_snakeHead.position - _nextPositions[0]).normalized;

            _nextPositions.Insert(0, _nextPositions[0] + direction * _circleDiameter);
            _nextPositions.RemoveAt(_nextPositions.Count - 1);

            distance -= _circleDiameter;
        }

        for (int i = 0; i < _snakeCircles.Count; i++)
        {
            _snakeCircles[i].position = Vector2.Lerp(_nextPositions[i + 1], _nextPositions[i], distance / _circleDiameter);
        }
    }

    private void ResetSnakePosition() 
    {
        _snakeHead.position = _startPosition;
    }

    public void AddTailBone()
    {
        GameObject circle = Instantiate(_tailPrefab, _nextPositions[_nextPositions.Count - 1], Quaternion.identity);
        _snakeCircles.Add(circle.transform);
        _nextPositions.Add(circle.transform.position);
    }

    public void RemoveTailBone()
    {
        for (int i = 0; i < _snakeCircles.Count; i++)
        {
            _nextPositions.RemoveAt(1);
            Destroy(_snakeCircles[i].gameObject);
        }
        _snakeCircles.Clear();
        ResetSnakePosition();
    }
}

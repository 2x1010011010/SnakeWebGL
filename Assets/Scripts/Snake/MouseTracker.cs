using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    private Vector2 _position;

    public Vector2 Position => _position;

    private void Update()
    {
        _position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Snake _target;

    private void Update()
    {
        transform.position = _target.transform.position;
    }
}

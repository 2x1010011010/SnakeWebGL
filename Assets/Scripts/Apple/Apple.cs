using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private int _value;

    public int Value => _value;
}
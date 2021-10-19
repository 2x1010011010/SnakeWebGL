using UnityEngine;

public class AppleReplacer : MonoBehaviour
{
    [SerializeField] private GameObject _stubPrefab;

    public void Change(GameObject apple)
    {
        GameObject replaced = Instantiate(_stubPrefab, apple.transform);
        Destroy(apple);
        replaced.SetActive(true);
    }

    
}
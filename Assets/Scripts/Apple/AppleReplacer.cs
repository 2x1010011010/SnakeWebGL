using UnityEngine;

public class AppleReplacer : MonoBehaviour
{
    [SerializeField] private GameObject _stubPrefab;

    public void Change(GameObject apple)
    {
        GameObject replaced = Instantiate(_stubPrefab, apple.transform);
        Debug.Log(" Instantiate ");
        replaced.SetActive(true);
        Debug.Log(" SetActive ");
        Destroy(apple);
        Debug.Log(" Destroy Apple ");
    }

    
}
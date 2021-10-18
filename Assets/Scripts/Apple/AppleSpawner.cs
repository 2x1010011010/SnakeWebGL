using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _applePrefabs;
    [SerializeField] private List<GameObject> _spawners = new List<GameObject>();

    private float _elapsedTime;
    private bool _isAplleSpawned;

    private void Start()
    {
        _isAplleSpawned = false;
    }

    private void Update()
    {
        if (_isAplleSpawned)
        {
            return;
        }
        else
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        _isAplleSpawned = true;

        int randomPrefabIndex = Random.Range(0, _applePrefabs.Length);
        int randomSpawnerIndex = Random.Range(0, _spawners.Count);
        GameObject spawned = Instantiate(_applePrefabs[randomPrefabIndex], _spawners[randomSpawnerIndex].transform);
        spawned.SetActive(true);
    }

    public void ResetSpawner()
    {
        _isAplleSpawned = false;
    }
}

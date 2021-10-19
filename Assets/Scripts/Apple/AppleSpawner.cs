using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _applePrefabs;
    [SerializeField] private List<GameObject> _spawners = new List<GameObject>();

    private AppleReplacer _appleReplacer;
    private bool _isAplleSpawned;
    private GameObject _spawned;

    private void Start()
    {
        _isAplleSpawned = false;
        _appleReplacer = GetComponent<AppleReplacer>();
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
        _spawned = Instantiate(_applePrefabs[randomPrefabIndex], _spawners[randomSpawnerIndex].transform);
        _spawned.SetActive(true);
    }

    public void ResetSpawner()
    {
        _appleReplacer.Change(_spawned);
        _isAplleSpawned = false;
    }
}

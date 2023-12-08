using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _maxAmountOfResources = 5;
    [SerializeField] private List<Resource> _resources;
    [SerializeField] private Resource _resource;

    private float _spawnPosX = 10;
    private float _spawnPosZ = 10;
    private float _spawnPozY = 0.54f;

    public event UnityAction <Resource> ResourceSpawned;

    private void Update()
    {
        if (_resources.Count < _maxAmountOfResources)
        {
            SpawnResource();
        }
    }

    public void TransferResource(Resource resource)
    {
        _resources.Remove(resource);
    }

    private void SpawnResource()
    {
        Resource resource = Instantiate(_resource, GenerateRandomSpawnPosition(), Quaternion.identity);
        _resources.Add(resource);
        ResourceSpawned?.Invoke(resource);
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnPosX, _spawnPosX), _spawnPozY, Random.Range(-_spawnPosZ, _spawnPosZ));
        return spawnPos;
    }
}

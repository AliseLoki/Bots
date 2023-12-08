using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _maxAmountOfResources = 5;
    [SerializeField] private List<Resource> _resources;
    [SerializeField] private Resource _resource;

    public event UnityAction<Resource> ResourceSpawned;

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
        float spawnPosX = 10;
        float spawnPosZ = 10;
        float spawnPozY = 0.54f;

        return new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPozY, Random.Range(-spawnPosZ, spawnPosZ));
    }
}

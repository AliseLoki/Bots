using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const string SpawnResources = nameof(SpawnResource);
  
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private float _spawnDelay = 1f;
    [SerializeField] private Resource _resource;

    private void Start()
    {
        InvokeRepeating(SpawnResources, _spawnDelay, _repeatRate);
    }

    private void SpawnResource()
    {
        Instantiate(_resource, GenerateRandomSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        float spawnPosX = 10;
        float spawnPosZ = 10;
        float spawnPozY = 0.5f;

        return new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPozY, Random.Range(-spawnPosZ, spawnPosZ));
    }
}

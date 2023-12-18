using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const string SpawnResources = nameof(SpawnResource);

    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private float _spawnDelay = 1f;
    [SerializeField] private Resource _resource;
    [SerializeField] private Base _baseTemplate;
    [SerializeField] private Bot _botTemplate;

    private void Start()
    {
        InvokeRepeating(SpawnResources, _spawnDelay, _repeatRate);
    }

    public Base SpawnBase( Transform point, Bot bot)
    {
        var offset = new Vector3(0, 0.5f, 0);
        var newBase =  Instantiate(_baseTemplate, point.position + offset, Quaternion.identity);
        newBase.AddBot(bot);
        return newBase;
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

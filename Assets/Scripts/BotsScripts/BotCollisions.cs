using UnityEngine;

[RequireComponent(typeof(BotMover))]
[RequireComponent(typeof (Bot))]
public class BotCollisions : MonoBehaviour
{
    private Resource _resource;
    private Spawner _spawner;
    private BotMover _mover;
    private Bot _bot;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
        _mover = GetComponent<BotMover>();
        _bot = GetComponent<Bot>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Resource resource) && resource.IsChosen && resource == _resource)
        {
            collision.transform.SetParent(transform);
            _mover.ReturnToBase();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Flag flag))
        {
            _mover.Stop();
            Destroy(flag.gameObject);
            transform.SetParent(_spawner.SpawnBase(flag.transform, GetComponent<Bot>()).transform);
            _mover.SetBase(GetComponentInParent<Base>());
            _bot.SetSended(false);
        }
    }

    public void SetResource(Resource resource)
    {
        _resource = resource;
    }
}

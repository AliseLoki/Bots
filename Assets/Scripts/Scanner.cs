using UnityEngine;
using UnityEngine.Events;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _sphereCastRadius = 2f;
    [SerializeField] private float _maxDistance = 50f;
    [SerializeField] private LayerMask _layerMask;

    public event UnityAction<Resource> ResourceWasFound;

    private void Update()
    {
        CheckArea();
    }

    private void CheckArea()
    {
        var resources = Physics.SphereCastAll(transform.position, _sphereCastRadius, transform.forward,
         _maxDistance, _layerMask, QueryTriggerInteraction.Ignore);

        foreach (var resource in resources)
        {
            ResourceWasFound?.Invoke(resource.collider.GetComponent<Resource>());
        }
    }
}

using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _maxdistance = 50f;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        CheckArea();
    }

    private void CheckArea()
    {
        if(Physics.SphereCast(transform.position, 50f, transform.forward, out RaycastHit hitInfo,
            _maxdistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            print(hitInfo.collider.name);
        }  
        
    }
}

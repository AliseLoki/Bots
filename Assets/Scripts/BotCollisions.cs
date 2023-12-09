using UnityEngine;

[RequireComponent (typeof(BotMover))]
public class BotCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Resource resource) && resource.IsChosen)
        {
            collision.transform.SetParent(transform);
            gameObject.GetComponent<BotMover>().ReturnToBase();
        }
    }
}

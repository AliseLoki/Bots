using UnityEngine;

[RequireComponent (typeof(BotMover))]
public class BotCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Resource resource) && transform.childCount == 0 && resource.IsTaken == false)
        {
            resource.SetIsTaken();
            collision.transform.SetParent(transform);
            gameObject.GetComponent<BotMover>().ReturnToBase();
        }
    }
}

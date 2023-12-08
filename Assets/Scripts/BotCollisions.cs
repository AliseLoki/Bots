using UnityEngine;

public class BotCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Resource resource) && transform.childCount == 0)
        {
            collision.transform.SetParent(transform);
            gameObject.GetComponent<BotMover>().ReturnToBase();
        }
    }
}

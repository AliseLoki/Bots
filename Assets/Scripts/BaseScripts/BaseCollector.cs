using UnityEngine;

public class BaseCollector : MonoBehaviour
{
    [SerializeField] private Base _base;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bot bot))
        {
            var givenResource = bot.GetComponentInChildren<Resource>();

            if (givenResource != null)
            {
                _base.AddResource(givenResource);
                givenResource.gameObject.SetActive(false);
                givenResource.transform.SetParent(transform);
                bot.Mover.MoveToStartPoint();
                _base.OnScoreChanged();
            }

            bot.SetBusy(false);
        }
    }
}

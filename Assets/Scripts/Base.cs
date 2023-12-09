using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private List<Bot> _bots;
    [SerializeField] private List<Resource> _resourcesWarehouse;
    [SerializeField] private Scanner _scanner;

    public event UnityAction<int> ScoreChanged;

    private void OnEnable()
    {
        _scanner.ResourceWasFound += SendBot;
    }

    private void OnDisable()
    {
        _scanner.ResourceWasFound -= SendBot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bot bot))
        {
            var givenResource = bot.GetComponentInChildren<Resource>();

            if (givenResource != null)
            {
                _resourcesWarehouse.Add(givenResource);
                givenResource.gameObject.SetActive(false);
                givenResource.transform.SetParent(transform);
                bot.GetComponent<BotMover>().MoveToStartPoint();
                OnScoreChanged();
            }

            bot.SetBusy(false);
        }
    }

    private void OnScoreChanged()
    {
        _score = _resourcesWarehouse.Count;
        ScoreChanged?.Invoke(_score);
    }

    private void SendBot(Resource resource)
    {
        foreach (Bot bot in _bots)
        {
            if (bot.IsBusy == false && resource.IsChosen == false )
            {
                bot.GetComponent<BotMover>().MoveToResource(resource.transform);
                bot.SetBusy(true);
                resource.SetIsChosen();
            }
        }
    }
}

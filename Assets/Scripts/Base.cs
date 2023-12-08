using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<Bot> _bots;
    [SerializeField] private List<Resource> _resourcesWarehouse;
    [SerializeField] private GameObject _warehouse;

    public event UnityAction<int> ScoreChanged;

    private void OnEnable()
    {
        _spawner.ResourceSpawned += SendBot;
    }

    private void OnDisable()
    {
        _spawner.ResourceSpawned -= SendBot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bot bot))
        {
            var givenResource = bot.GetComponentInChildren<Resource>();

            if (givenResource != null )
            {
                _spawner.TransferResource(givenResource);
                _resourcesWarehouse.Add(givenResource);
                givenResource.gameObject.SetActive(false);
                givenResource.transform.SetParent(_warehouse.transform);
                bot.GetComponent<BotMover>().MoveToStartPoint();
                bot.SetBusy(false);
                OnScoreChanged();
            }
            else
            {
                bot.SetBusy(false);
            }
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
            if (bot.IsBusy == false && resource.IsChosen == false)
            {
                bot.GetComponent<BotMover>().MoveToResource(resource.transform);
                bot.SetBusy(true);
                resource.GetComponent<Resource>().SetIsChosen();
            }
        }
    }
}
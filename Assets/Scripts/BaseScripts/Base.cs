using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private Bot _botTemplate;
    [SerializeField] private List<Bot> _bots;
    [SerializeField] private List<Resource> _resourcesWarehouse;
    [SerializeField] private Scanner _scanner;
    [SerializeField] private FlagCreator _flagCreator;

    private int _basePrice = 5;
   
    public Bot BotTemplate => _botTemplate;

    public List<Bot> Bots => _bots;
    public List<Resource> ResourcesWarehouse => _resourcesWarehouse;

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
                bot.Mover.MoveToStartPoint();
                OnScoreChanged();
            }

            bot.SetBusy(false);
        }
    }

    public void AddBot(Bot bot)
    {
        _bots.Add(bot);
    }

    public void RemoveBot(Bot bot)
    {
        _bots.Remove(bot);
    }

    public void Pay(int price)
    {
        _resourcesWarehouse.RemoveRange(0, price);
        _score -= price;
        ScoreChanged?.Invoke(_score);
    }

    private void OnScoreChanged()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    private void SendBot(Resource resource)
    {
        if (_flagCreator.HasFlag == false || _score < _basePrice)
        {
            SendBotsToResources(resource);
        }
        else
        {
            var sendedBot = _bots[0];
            sendedBot.SetSended(true);
            Pay(_basePrice);
            sendedBot.Mover.MoveToTarget(_flagCreator.Flag.transform);
            _flagCreator.RemoveFlag();
            SendBotsToResources(resource);
        }
    }

    private void SendBotsToResources(Resource resource)
    {
        foreach (Bot bot in _bots)
        {
            if (bot.IsBusy == false && resource.IsChosen == false && bot.IsSendedToBuild == false)
            {
                SendBotToResource(bot, resource);
            }
        }
    }

    private void SendBotToResource(Bot bot, Resource resource)
    {
        bot.Mover.MoveToTarget(resource.transform);
        bot.Collector.SetResource(resource);
        bot.SetBusy(true);
        resource.SetIsChosen();
    }
}

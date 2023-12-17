using UnityEngine;

[RequireComponent(typeof(BotMover))]
[RequireComponent(typeof(BotCollisions))]
public class Bot : MonoBehaviour
{
    [SerializeField] private bool _isBusy;
    [SerializeField] private bool _isSendedToBuild;

    public BotCollisions Collector { get; private set; }
    public BotMover Mover { get; private set; }

    public bool IsBusy => _isBusy;
    public bool IsSendedToBuild => _isSendedToBuild;

    private void Awake()
    {
        Collector = GetComponent<BotCollisions>();
        Mover = GetComponent<BotMover>();
    }

    public bool SetBusy(bool isBusy)
    {
        _isBusy = isBusy;
        return _isBusy;
    }

    public bool SetSended(bool isSended)
    {
        _isSendedToBuild = isSended;
        return _isBusy;
    }
}

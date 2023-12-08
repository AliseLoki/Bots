using UnityEngine;

[RequireComponent (typeof(BotMover))]
[RequireComponent(typeof(BotCollisions))]
public class Bot : MonoBehaviour
{
    [SerializeField] private bool _isBusy;
    
    private BotMover _botMover;
    public bool IsBusy => _isBusy;
 
    private void Awake()
    {
        _botMover = GetComponent<BotMover>();
    }

    public bool SetBusy(bool busyOrNot)
    {
        _isBusy = busyOrNot; 
        return _isBusy;
    }
}

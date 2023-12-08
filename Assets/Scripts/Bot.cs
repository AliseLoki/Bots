using UnityEngine;

[RequireComponent (typeof(BotMover))]
[RequireComponent(typeof(BotCollisions))]
public class Bot : MonoBehaviour
{
    [SerializeField] private bool _isBusy;
  
    public bool IsBusy => _isBusy;
 
    public bool SetBusy(bool isBusy)
    {
        _isBusy = isBusy; 
        return _isBusy;
    }
}

using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private bool _isChosen = false;
    [SerializeField] private bool _isTaken = false;

    public bool IsChosen => _isChosen;
    public bool IsTaken => _isTaken;

    public void SetIsChosen()
    {
        _isChosen = true;
    }

    public void SetIsTaken()
    {
        _isTaken = true;
    }
}

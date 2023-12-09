using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private bool _isChosen = false;
    
    public bool IsChosen => _isChosen;
    
    public void SetIsChosen()
    {
        _isChosen = true;
    }
}

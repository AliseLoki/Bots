using UnityEngine;

public class BotCreator : MonoBehaviour
{
    [SerializeField] private Base _base;
  
    private int _botsPrice = 3;

    private void Update()
    {
        CheckWarehouse();
    }

    private void CheckWarehouse()
    {
        if (_base.ResourcesWarehouse.Count >= _botsPrice && _base.GetComponent<FlagCreator>().HasFlag == false)
            CreateBot();    
    }

    public void CreateBot()
    {
        var bot = Instantiate(_base.BotTemplate, transform, true);
        _base.AddBot(bot);
        _base.Pay(_botsPrice);
    }
}

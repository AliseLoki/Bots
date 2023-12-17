using UnityEngine;
using UnityEngine.UI;

public class BotCreator : MonoBehaviour
{
    [SerializeField] private Base _base;
    private Button _createBotButton;

    private int _botsPrice = 3;

    private void OnEnable()
    {
        _createBotButton = GameObject.FindObjectOfType<Button>(true);
    }

    private void Update()
    {
        CheckWarehouse();
    }

    private void CheckWarehouse()
    {
        if (_base.ResourcesWarehouse.Count >= _botsPrice && _base.GetComponent<FlagCreator>().HasFlag == false)
            _createBotButton.gameObject.SetActive(true);
        else
            _createBotButton.gameObject.SetActive(false);
    }

    public void CreateBot()
    {
        var bot = Instantiate(_base.BotTemplate, transform, true);
        _base.AddBot(bot);
        _base.Pay(_botsPrice);
    }
}

using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class FlagCreator : MonoBehaviour
{
    [SerializeField] private Flag _flagTemplate;

    private bool _hasFlag;
    private bool _baseClicked;
    private int _mouseClickCounter = 2;
    private int _mouseClicks = 1;
    private Flag _flag;

    public bool HasFlag => _hasFlag;
    public Flag Flag => _flag;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _baseClicked)
        {
            SendRaycast();
        }
    }

    private void OnMouseDown()
    {
        _baseClicked = true;
        ChangeBaseColor(Color.yellow);
    }

    public void RemoveFlag()
    {
        _hasFlag = false;
    }

    private void SendRaycast()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
        {
            if (_mouseClickCounter == _mouseClicks)
            {
                if (_hasFlag == false)
                {
                    AddFlag(hitInfo.point);
                }
                else if (hitInfo.collider.gameObject != gameObject)
                {
                    MoveFlag(hitInfo.point);
                }

                Reset();
            }
            else
            {
                _mouseClickCounter--;
            }
        }
    }

    private void Reset()
    {
        _mouseClickCounter += _mouseClicks;
        _baseClicked = false;
        ChangeBaseColor(Color.green);
    }

    private void MoveFlag(Vector3 point)
    {
        _flag.transform.position = point;
    }

    private void AddFlag(Vector3 point)
    {
        _flag = Instantiate(_flagTemplate, point, Quaternion.identity);
        _hasFlag = true;
    }

    private void ChangeBaseColor(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}

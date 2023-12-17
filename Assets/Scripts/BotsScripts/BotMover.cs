using System.Collections;
using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Base _base;
    private Transform _startPoint;
    private Coroutine _coroutine;

    private void Awake()
    {
        _startPoint = transform;
        _base = GetComponentInParent<Base>();
    }

    public void SetBase(Base newBase)
    {
        _base = newBase;
    }

    public void MoveToStartPoint()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Moving(_startPoint));
    }

    public void ReturnToBase()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Moving(_base.transform));
    }

    public void MoveToTarget(Transform target)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (target != null)
        {
            _coroutine = StartCoroutine(Moving(target));
        }
    }

    public void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private IEnumerator Moving(Transform target)
    {
        while (transform.position != target.position)
        {
            Move(target);
            yield return null;
        }
    }
}

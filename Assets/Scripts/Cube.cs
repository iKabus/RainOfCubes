using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _minLifetime = 2;
    [SerializeField] private int _maxLifeTime = 6;

    private Action<Cube> _returnToPool;

    private bool _isScheduledForRemoval = false;

    public void Init(Action<Cube> returnAction)
    {
        _returnToPool = returnAction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground) && !_isScheduledForRemoval)
        {
            ScheduleRemoval();
        }
    }

    private void ScheduleRemoval()
    {
        _isScheduledForRemoval = true;

        float delay = UnityEngine.Random.Range(_minLifetime, _maxLifeTime);
        
        Invoke(nameof(ReturnToPool), delay);
    }

    private void ReturnToPool()
    {
        if (!_isScheduledForRemoval) return;

        _isScheduledForRemoval = false;
        
        _returnToPool?.Invoke(this);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(ReturnToPool));
        
        _isScheduledForRemoval = false;
    }
}
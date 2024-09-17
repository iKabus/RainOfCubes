using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public bool IsContact { get; private set; } = true;

    private int _minLifetime = 2;
    private int _maxLifeTime = 6;

    private Renderer _renderer;

    private Action<Cube> _contact;

    public void Contact()
    {
        IsContact = !IsContact;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            if (IsContact == false)
            {
                return;
            }
            
            Invoke(nameof(RemoveToPool), UnityEngine.Random.Range(_minLifetime, _maxLifeTime));
        }
    }

    public void Init(Action<Cube> contact)
    {
        _renderer = GetComponent<Renderer>();

        _contact = contact;
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }
 
    private void RemoveToPool()
    {
        IsContact = true;

        _contact(this);
    }
}

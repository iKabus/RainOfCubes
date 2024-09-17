using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public event Action<Cube> onContact;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Cube cube)){
            onContact?.Invoke(cube);
        }
    }
}
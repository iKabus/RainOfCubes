using System;
using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    
    public static event Action<Vector3> CubeRemoved;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.0f, _repeatRate);
    }

    protected override void Spawn()
    {
        for (int i = 0; i < Mathf.Min(_spawnAmount, _poolMaxSize); i++)
        {
            var cube = _pool.Get();
            cube.Init(RemoveToPool);
            cube.transform.position = GetPosition();
        }
    }

    private void RemoveToPool(Cube cube)
    {
        if (cube.gameObject.activeInHierarchy)
        {
            _pool.Release(cube);
            
            CubeRemoved?.Invoke(cube.transform.position);
        }
    }
}
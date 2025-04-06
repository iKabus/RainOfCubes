using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    private BombSpawner _bombSpawner;

    protected override void Awake()
    {
        base.Awake();
        _bombSpawner = FindFirstObjectByType<BombSpawner>();
    }

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
            SpawnBomb(cube.transform.position);
        }
    }

    private void SpawnBomb(Vector3 position)
    {
        if (_bombSpawner != null)
        {
            _bombSpawner.SpawnAt(position);
        }
    }
}
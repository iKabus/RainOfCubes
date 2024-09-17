using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private int _spawnAmount = 20;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private readonly float _minCoordinateValue = -5f;
    private readonly float _maxCoordinateValue = 5f;

    private readonly Color _defaultColor = new(0, 0, 0);

    private ObjectPool<Cube> _pool;
    
    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefabCube),
            actionOnGet: cube => cube.gameObject.SetActive(true),
            actionOnRelease: cube => cube.gameObject.SetActive(false),
            actionOnDestroy: cube => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.0f, _repeatRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            var cube = _pool.Get();
            cube.Init(RemoveToPool);
            cube.SetColor(_defaultColor);
            cube.transform.position = GetPosition();
        }
    }

    private Vector3 GetPosition()
    {
        const float coordinateY = 10;

        float coordinateX = Random.Range(_minCoordinateValue, _maxCoordinateValue);
        float coordinateZ = Random.Range(_minCoordinateValue, _maxCoordinateValue);

        return new Vector3(coordinateX, coordinateY, coordinateZ);
    }

    private void RemoveToPool(Cube cube)
    {
        _pool.Release(cube);
    }
}

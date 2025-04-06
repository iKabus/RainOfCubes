using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour, ISpawnerStats where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;
    [SerializeField] protected int _spawnAmount = 20;
    [SerializeField] protected float _repeatRate = 1f;
    [SerializeField] protected int _poolCapacity = 5;
    [SerializeField] protected int _poolMaxSize = 5;

    protected readonly float _minCoordinateValue = -5f;
    protected readonly float _maxCoordinateValue = 5f;

    protected ObjectPool<T> _pool;

    protected int _totalSpawned;
    protected int _totalCreated;

    public int TotalSpawned => _totalSpawned;
    public int TotalCreated => _totalCreated;
    public int ActiveCount => _pool.CountActive;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => {
                _totalCreated++;
                return Instantiate(_prefab);
            },
            actionOnGet: obj => {
                obj.gameObject.SetActive(true);
                _totalSpawned++;
            },
            actionOnRelease: obj => obj.gameObject.SetActive(false),
            actionOnDestroy: obj => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    protected Vector3 GetPosition()
    {
        const float coordinateY = 10;
        float coordinateX = Random.Range(_minCoordinateValue, _maxCoordinateValue);
        float coordinateZ = Random.Range(_minCoordinateValue, _maxCoordinateValue);
        return new Vector3(coordinateX, coordinateY, coordinateZ);
    }

    protected abstract void Spawn();
}
using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    public void SpawnAt(Vector3 position)
    {
        var bomb = _pool.Get();
        bomb.transform.position = position;
        bomb.Initialize(this);
    }

    public void ReleaseBomb(Bomb bomb)
    {
        _pool.Release(bomb);
    }

    protected override void Spawn()
    {
    }
}
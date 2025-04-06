using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    public void SpawnAt(Vector3 position)
    {
        var bomb = _pool.Get();
        bomb.transform.position = position;
    }

    protected override void Spawn()
    {
    }
}

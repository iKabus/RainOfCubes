using UnityEngine;

public class SpawnerStatsUI : MonoBehaviour
{
    [SerializeField] private SpawnerStatDisplay _cubeStatDisplay;
    [SerializeField] private SpawnerStatDisplay _bombStatDisplay;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    private void Start()
    {
        _cubeStatDisplay.Initialize(_cubeSpawner, "Cubes");
        _bombStatDisplay.Initialize(_bombSpawner, "Bombs");
    }
}

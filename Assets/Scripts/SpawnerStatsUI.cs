using TMPro;
using UnityEngine;

public class SpawnerStatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _cubeStatsText;
    [SerializeField] private TMP_Text _bombStatsText;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    private void Update()
    {
        _cubeStatsText.text = $"Cubes:\nTotal Spawned: {_cubeSpawner.TotalSpawned}\n" +
                             $"Total Created: {_cubeSpawner.TotalCreated}\n" +
                             $"Active: {_cubeSpawner.ActiveCount}";

        _bombStatsText.text = $"Bombs:\nTotal Spawned: {_bombSpawner.TotalSpawned}\n" +
                             $"Total Created: {_bombSpawner.TotalCreated}\n" +
                             $"Active: {_bombSpawner.ActiveCount}";
    }
}

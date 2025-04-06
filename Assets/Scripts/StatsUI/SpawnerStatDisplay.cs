using TMPro;
using UnityEngine;

public class SpawnerStatDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _statsText;
    [SerializeField] private MonoBehaviour _spawner;

    private string _title;
    private int _lastTotalSpawned = -1;
    private int _lastTotalCreated = -1;
    private int _lastActiveCount = -1;

    public void Initialize<T>(Spawner<T> spawner, string title) where T : MonoBehaviour
    {
        _spawner = spawner;
        _title = title;

        ForceUpdate();
    }

    private void Update()
    {
        if (_spawner == null) return;

        var spawner = _spawner as ISpawnerStats;

        if (spawner == null)
        {
            return;
        }

        if (_lastTotalSpawned != spawner.TotalSpawned ||
            _lastTotalCreated != spawner.TotalCreated ||
            _lastActiveCount != spawner.ActiveCount)
        {
            UpdateText(spawner);
        }
    }

    private void UpdateText(ISpawnerStats spawner)
    {
        _lastTotalSpawned = spawner.TotalSpawned;
        _lastTotalCreated = spawner.TotalCreated;
        _lastActiveCount = spawner.ActiveCount;

        _statsText.text = $"{_title}:\nTotal Spawned: {_lastTotalSpawned}\n" +
                         $"Total Created: {_lastTotalCreated}\n" +
                         $"Active: {_lastActiveCount}";
    }

    public void ForceUpdate()
    {
        _lastTotalSpawned = -1;

        UpdateText(_spawner as ISpawnerStats);
    }
}

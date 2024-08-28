using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Explosion _destruction;
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _cube.Clicked += Clicked;
    }

    private void OnDisable()
    {
        _cube.Clicked -= Clicked;
    }

    private void Clicked()
    {
        int minLimit = 2;
        int maxLimit = 7;
        int cubeNumber = Random.Range(minLimit, maxLimit);

        if (_cube.CanSplit())
        {
            for (int i = 0; i < cubeNumber; i++)
            {
                Create();
            }
        }
        else
        {
            _destruction.Increase(_cube.CurrentExpolosionParametr);
            _destruction.Explode();
        }

        Destroy(_cube.gameObject);
    }

    private void Create()
    {
        Cube cube = Instantiate(_cube);

        cube.Initialize(_cube.CurrentChance, _cube.CurrentExpolosionParametr);
    }
}

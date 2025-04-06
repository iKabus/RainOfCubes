using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ColorChanger), typeof(Exploder))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _minFadeTime = 2f;
    [SerializeField] private float _maxFadeTime = 5f;

    private ColorChanger _colorChanger;
    private Exploder _exploder;
    private BombSpawner _spawner;

    public void Initialize(BombSpawner spawner)
    {
        _spawner = spawner;
    }

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _exploder = GetComponent<Exploder>();

        StartCoroutine(FadeAndExplode());
    }

    private IEnumerator FadeAndExplode()
    {
        float fadeTime = Random.Range(_minFadeTime, _maxFadeTime);
        yield return _colorChanger.FadeOut(fadeTime);

        _exploder.Explode(transform.position);
        _spawner.ReleaseBomb(this);
    }
}
using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action Clicked;

    private float _divider = 2f;

    private float _minChanceSplit = 0f;
    private float _maxChanceSplit = 100f;

    public float CurrentChance { get; private set; } = 100f;
    public float CurrentExpolosionParametr { get; private set; } = 1f;

    public bool CanSplit()
    {
        float chance = UnityEngine.Random.Range(_minChanceSplit, _maxChanceSplit);

        return CurrentChance >= chance;
    }

    public void Initialize(float parentChance, float parentExplosionParametr)
    {
        SetChance(parentChance);
        SetExplosionParametr(parentExplosionParametr);
        ChangeColor();
        ChangeScale();
    }

    private void SetChance(float parentChance)
    {
        CurrentChance = parentChance / _divider;
    }

    private void SetExplosionParametr(float parentExplosionParametr)
    {
        CurrentExpolosionParametr = parentExplosionParametr * _divider;
    }

    private void ChangeColor()
    {
        if (TryGetComponent<Renderer>(out Renderer component))
        {
            component.material.color = UnityEngine.Random.ColorHSV();
        }
    }

    private void ChangeScale()
    {
        int scaleChange = 2;

        transform.localScale /= scaleChange;
    }

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke();
    }
}

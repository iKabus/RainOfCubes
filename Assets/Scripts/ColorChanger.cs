using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Ground[] _grounds;

    private Renderer _renderer;

    private void OnEnable()
    {
        foreach (var ground in _grounds)
        {
            ground.onContact += SetRandomColor;
        }
    }

    private void OnDisable()
    {
        foreach (var ground in _grounds)
        {
            ground.onContact -= SetRandomColor;
        }
    }

    private void SetRandomColor(Cube cube)
    {
        if (cube.IsContact)
        {
            _renderer = cube.GetComponent<Renderer>();

            _renderer.material.color = CreateRandomColor;

            cube.Contact();
        }
    }

    private Color CreateRandomColor => Random.ColorHSV();
}

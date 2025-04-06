using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _minFadeTime = 2f;
    [SerializeField] private float _maxFadeTime = 5f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 500f;

    private Renderer _renderer;
    private Material _material;
    private Color _initialColor;
    private float _fadeTime;
    private float _currentAlpha = 1f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;

        _material.SetFloat("_Mode", 2);
        _material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        _material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        _material.EnableKeyword("_ALPHABLEND_ON");
        _material.renderQueue = 3000;

        _initialColor = Color.black;
        _material.color = _initialColor;

        _fadeTime = Random.Range(_minFadeTime, _maxFadeTime);
    }

    private void Update()
    {
        _currentAlpha -= Time.deltaTime / _fadeTime;
        _material.color = new Color(_initialColor.r, _initialColor.g, _initialColor.b, _currentAlpha);

        if (_currentAlpha <= 0f)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody riginbody = hit.GetComponent<Rigidbody>();
            
            if (riginbody != null)
            {
                riginbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}
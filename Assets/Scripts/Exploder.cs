using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 500f;

    public void Explode(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius);
            }
        }
    }
}
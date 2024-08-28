using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Force { get; private set; } = 20f;
    public float Radius { get; private set; } = 20f;

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObject())
        {
            explodableObject.AddExplosionForce(Force, transform.position, Radius);
        }
    }

    public void Increase(float currentParametr)
    {
        Force *= currentParametr;
        Radius *= currentParametr;
    }

    private List<Rigidbody> GetExplodableObject()
    {
        float radius = 10f;

        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        List<Rigidbody> units = new();

        units.AddRange(hits.Where(hit => hit.attachedRigidbody != null).Select(hit => hit.attachedRigidbody));

        return units;
    }
}

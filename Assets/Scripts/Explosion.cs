using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    
    public void Explode(List<Cube> cubes, Vector3 position)
    {
        foreach (Cube cube in cubes)
        {
           Rigidbody rbCube =  cube.GetComponent<Rigidbody>();
           rbCube.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }
}

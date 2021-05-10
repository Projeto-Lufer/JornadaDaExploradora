using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask targetLayer;

    [Header("Target area parameters")]
    [SerializeField] private float fov = 90f;
    [SerializeField] private float distance = 5f;

    private float angle;
    private Vector3 origin;
    int rayCount = 50;
    float angleIncrease;
    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;
    Mesh AOEMesh;
    float startingAngle;

    public float sweepRange;

    public int weaponDamage;

    public void Sweep()
    {
        Collider[] targets = Physics.OverlapSphere(attackPoint.position, sweepRange, targetLayer);

        foreach (Collider target in targets)
        {
            target.GetComponent<HealthPoints>().ReduceHealth(weaponDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        float startingAngle = Mathf.Atan2(transform.forward.z, transform.forward.x) * Mathf.Rad2Deg;
        if (startingAngle < 0) startingAngle += 360f;
        
        angle = startingAngle + fov/2;
        origin = transform.position;
        AOEMesh = new Mesh();
        angleIncrease = fov / rayCount;
        vertices = new Vector3[rayCount + 1 + 1];
        uv = new Vector2[vertices.Length];
        triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= rayCount ; ++i)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            Vector3 vectorAngle = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));

            Vector3 vertex = origin + vectorAngle * distance;
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            ++vertexIndex;
            angle -= angleIncrease;

        }

        AOEMesh.vertices = vertices;
        AOEMesh.uv = uv;
        AOEMesh.triangles = triangles;

        AOEMesh.RecalculateNormals();
        Gizmos.color = Color.red;
        Gizmos.DrawMesh(AOEMesh);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour
{
    [Header("External references")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private AudioClip attackSFX;
    [SerializeField] private AudioManager audioManager;

    [Header("Gameplay tweeking fields")]
    [SerializeField] private LayerMask targetLayer;

    [Header("Target area parameters")]
    [SerializeField] private float fov = 90f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private int rayCount = 50;
    [SerializeField] private float sweepRange;
    [SerializeField] private bool showRays;

    float angleIncrease;

    List<Collider> targetsAlreadyHit = new List<Collider>();

    private void Awake()
    {
        angleIncrease = fov / rayCount;
    }

    public void Sweep(ComboElement element)
    {
        StartCoroutine(SweepRoutine(element));
    }

    private IEnumerator SweepRoutine(ComboElement element)
    {
        float raysToCast = 0;
        float totalRaysCast = 0;
        float raysRemaining = (float)rayCount;
        float startingAngle = VectorToAngle(transform.forward);

        float currentAngle;
        if(element.goesRightToLeft)
            currentAngle = startingAngle - fov / 2;
        else
            currentAngle = startingAngle + fov/2;

        targetsAlreadyHit.Clear();
        float lastTotalTime = 0;

        audioManager.PlaySFX(attackSFX, true, false);

        for (float time = 0; time <= element.duration; time += Time.deltaTime)
        {
            float timeIncrementPercentage = time / element.duration - lastTotalTime;
            lastTotalTime = time / element.duration;

            raysToCast += raysRemaining * timeIncrementPercentage;

            if (raysToCast >= 1)
            {
                int i = 0;
                do
                {
                    this.DoDamage(this.CastNextRay(currentAngle), element);
                    if(element.goesRightToLeft)
                        currentAngle += angleIncrease;
                    else
                        currentAngle -= angleIncrease;
                    totalRaysCast++;

                    ++i;
                } while (i < (int)raysToCast);
                
                raysToCast -= i;
            }
            else if(time == 0)
            {
                this.DoDamage(this.CastNextRay(currentAngle), element);
                if (element.goesRightToLeft)
                    currentAngle += angleIncrease;
                else
                    currentAngle -= angleIncrease;
                totalRaysCast++;
            }
            yield return null;
        }
    }

    private RaycastHit[] CastNextRay(float currentAngle)
    {
        Vector3 vectorAngle = VectorFromAngle(currentAngle);        
        Vector3 directionAndDistance = vectorAngle * radius;

        if (showRays)
            Debug.DrawRay(attackPoint.position, directionAndDistance, Color.blue, 0.2f, true);

        return Physics.RaycastAll(attackPoint.position, vectorAngle, radius, targetLayer, QueryTriggerInteraction.Ignore);
    }

    private void DoDamage(RaycastHit[] hits, ComboElement element)
    {
        bool shield = false;
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag == "Shield")
            {
                shield = true;
            }
        }

        if (shield == false)
        {
            foreach (RaycastHit hit in hits)
            {
                // trocar isso para algo como os alvos terem uma invulnerabilidade temporaria, para evitar ter que ficar mexendo com lista
                if (!targetsAlreadyHit.Contains(hit.collider))
                {
                    HealthPoints hp = hit.collider.GetComponent<HealthPoints>();
                    if (hp != null)
                    {
                        hp.ReduceHealth(element);
                    }
                    if(element.knockback > 0)
                    {
                        Vector3 direction = hit.collider.transform.position - transform.position;
                        direction.y = 0;
                        Rigidbody rb = hit.collider.transform.parent.GetComponent<Rigidbody>();
                        if(rb != null)
                        {
                            rb.AddForce(direction * element.knockback, ForceMode.Impulse);
                            StartCoroutine(removeKnockbackForce(rb, element.knockbackTime));
                        }
                    }
                    targetsAlreadyHit.Add(hit.collider);
                }
            }
        }
    }

    private IEnumerator removeKnockbackForce(Rigidbody rb, float t)
    {
        yield return new WaitForSeconds(t);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    private float VectorToAngle(Vector3 direction)
    {
        float newAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        if (newAngle < 0) newAngle += 360f;

        return newAngle;
    }

    private static Vector3 VectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);

        return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
    }

    #region Attack Area Gizmo
    // Gizmo variables
    private float angle;
    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;
    Mesh AOEMesh;

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        float startingAngle = VectorToAngle(attackPoint.forward);
        
        angle = startingAngle + fov/2;
        angleIncrease = fov / rayCount;
        AOEMesh = new Mesh();
        vertices = new Vector3[rayCount + 1 + 1];
        uv = new Vector2[vertices.Length];
        triangles = new int[rayCount * 3];

        vertices[0] = attackPoint.position;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= rayCount ; ++i)
        {
            Vector3 vectorAngle = VectorFromAngle(angle);

            Vector3 vertex = attackPoint.position + vectorAngle * radius;
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
    #endregion
}

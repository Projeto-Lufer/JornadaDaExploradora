using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3 (followTarget.position.x - transform.position.x, 
                                followTarget.position.y - transform.position.y, 
                                followTarget.position.z - transform.position.z);
    }

    void Update()
    {
        if(followTarget != null)
        {
            transform.position = followTarget.position - offset;
        }
    }
}

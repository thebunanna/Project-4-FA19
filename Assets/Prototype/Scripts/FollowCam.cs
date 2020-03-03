using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float speed = 1;

    float lerp;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.x = target.position.x;
        float s = speed;

        if (Vector3.Distance(targetPosition, transform.position) > 10)
        {
            s = speed * 3;
        }

        lerp = Mathf.Lerp(lerp, s, Time.fixedDeltaTime * 5);
        //v.y = transform.position.y;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * lerp);
    }
}

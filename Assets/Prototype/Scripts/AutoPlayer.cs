using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayer : MonoBehaviour
{
    public List<GameObject> waypoints = new List<GameObject>();

    const float speed = 10;

    bool grounded;
    int index;
    Rigidbody rb;
    LayerMask layerMask = -1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        waypoints.RemoveAll(x => x == null);
        layerMask &= ~(1 << gameObject.layer);
    }

    void Update()
    {
        if (waypoints.Count > 0)
        {
            Vector3 v = waypoints[index].transform.position; v.y = transform.position.y;
            Quaternion r = Quaternion.LookRotation(v - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, r, Time.deltaTime * 5);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {

        grounded = Physics.CheckSphere(transform.position - transform.up * 0.2f, 0.4f, layerMask.value);

        Vector3 velocity = transform.TransformDirection(Vector3.forward) * speed;
        velocity.y = rb.velocity.y;
        if (grounded) { rb.velocity = velocity; }
        rb.AddForce(Physics.gravity * 2, ForceMode.Force);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject == waypoints[index])
        {
            Destroy(waypoints[index]);
            waypoints.RemoveAt(0);
        }
    }
}

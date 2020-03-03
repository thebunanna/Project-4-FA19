using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float speed = 10;

    Transform target;
    Quaternion rot;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        speed *= Random.Range(0.75f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) > 5)
            {
                rot = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10);
                velocity = transform.TransformDirection(Vector3.forward) * speed;
            }

            if (Vector3.Distance(transform.position, target.position) < 3)
            {
                velocity = transform.TransformDirection(Vector3.back) * speed;
            }

            velocity.y = rb.velocity.y;
            rb.velocity = Vector3.Lerp(rb.velocity, velocity, Time.deltaTime * 5);
        }
    }

    public void Reverse()
    {
        CancelInvoke();
        speed *= -1;
        GetComponent<Renderer>().material.color = Color.blue;
        Invoke("Reset", Random.Range(3f, 5f));
    }

    void Reset()
    {
        speed *= -1;
        GetComponent<Renderer>().material.color = Color.white;
    }
}

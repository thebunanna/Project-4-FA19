using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatthewDemo : MonoBehaviour
{
    public float speed = 1;
    public float turnSpeed = 1;
    public float jumpForce = 1;

    float h;
    float v;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }
}

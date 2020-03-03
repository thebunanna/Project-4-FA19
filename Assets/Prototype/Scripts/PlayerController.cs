using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static GameObject last;
    public static int cloneCount;

    public float resetHeight = -50;

    float speed = 10;

    bool grounded;
    Rigidbody rb;
    Vector3 motionVector;

    void Start()
    {
        Time.fixedDeltaTime = 1 / 100f;
        rb = GetComponent<Rigidbody>();
        last = gameObject;
        Cursor.visible = false;
        InvokeRepeating("Clock", 1, 1);

        SmoothFollowTargets.AddTarget(gameObject);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputVector *= speed;
        inputVector.y = rb.velocity.y;
        rb.velocity = Vector3.Lerp(rb.velocity, inputVector, Time.deltaTime * 15);
        
        if (gameObject == last)
        {
            if (Input.GetButtonDown("Jump") && cloneCount < 4)
            {
                GameObject g = Instantiate(gameObject, transform.position + transform.forward, transform.rotation);
                RaycastHit hit;
                Physics.Raycast(transform.position + Vector3.forward * 5 + Vector3.up * 50, Vector3.down, out hit, 100);
                g.transform.position = hit.point + Vector3.up / 2f;
                foreach (Renderer r in g.GetComponentsInChildren<Renderer>())
                {
                    r.material.color -= new Color(0.1f, 0, 0);
                }
                cloneCount++;
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * 5, ForceMode.Force);
    }

    void Clock()
    {
        if (transform.position.y < resetHeight) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    }
}
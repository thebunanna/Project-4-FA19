using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathBox : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(c.gameObject);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(c.gameObject);
        }
    }
}

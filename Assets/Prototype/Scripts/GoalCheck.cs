using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    public static List<GameObject> goals = new List<GameObject>();

    public static void AddObject(GameObject g)
    {
        if (!goals.Contains(g))
        {
            goals.Add(g);
        }
    }

    public float delay = 3;
    public string message = "Level Complete";
    public Text uiText;
    public bool reload;

    void Awake()
    {
        goals = new List<GameObject>();
        PlayerController.cloneCount = 0;
    }

    void OnEnable()
    {
        InvokeRepeating("Check", 0, 0.5f);
    }

    void Check()
    {
        foreach (var g in goals)
        {

            if (!g.GetComponent<Goal>().touch)
            {
                return;
            }
        }

        if (uiText != null) uiText.text = message;
        Invoke("Load", 3);

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (g != null)
            {
                g.GetComponent<PlayerController>().enabled = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Load();
        }
    }

    void Load()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;

        if (index == SceneManager.sceneCountInBuildSettings)
        {
            index = 0;
        }

        if (reload)
        {
            index = SceneManager.GetActiveScene().buildIndex;
        }

        SceneManager.LoadScene(index);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IntroLevel : MonoBehaviour
{
    public string message = "Level 1";
    public Text uiText;

    // Use this for initialization
    void Start()
    {
        if (uiText != null)
        {
            uiText.text = message;
            Invoke("ClearText", 3);
        }
    }

    void ClearText()
    {
        uiText.text = "";
    }
}

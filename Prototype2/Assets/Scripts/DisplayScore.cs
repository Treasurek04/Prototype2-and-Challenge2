using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text textbox;
    public int score = 0;

    void Start()
    {
        if (textbox == null)
        {
            textbox = GetComponent<Text>();
        }

        if (textbox != null)
        {
            textbox.text = "Score: 0";
        }
        else
        {
            Debug.LogError("Textbox is not assigned and was not found on the GameObject.");
        }
    }

    void Update()
    {
        if (textbox != null)
        {
            textbox.text = "Score: " + score;
        }
    }
}

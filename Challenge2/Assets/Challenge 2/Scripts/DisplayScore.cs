using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DisplayScore : MonoBehaviour
{
    public Text textbox;
    public int score = 0;
    public bool gameOver = false;
    public GameObject youWinText;

    void Start()
    {
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    void Update()
    {
        textbox.text = "Score: " + score;

        if (score >= 5)
        {
            gameOver = true;
            youWinText.SetActive(true);

            FindObjectOfType<SpawnManagerX>().gameOver = true; 
        }

        if (Input.GetKeyDown( KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}

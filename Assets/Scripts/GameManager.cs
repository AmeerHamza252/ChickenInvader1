using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text textScore;
    public GameObject panel;
    public GameObject pausePanel;
    public bool isGamePaused;
    public bool showPauseText;
    public Text pauseText;
    // Start is called before the first frame update
    void Start()
    {
        showPauseText = false;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score:" + score;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             
            pauseText.text = "Pause";
            isGamePaused = !isGamePaused;
            PauseGame();
        }
    }

    public void addScore() 
    {
        score += 2;
    }

    public void restart() 
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void PauseGame() 
    {
        if (isGamePaused)
        {
            GetComponent<GameManager>().pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            GetComponent<GameManager>().pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

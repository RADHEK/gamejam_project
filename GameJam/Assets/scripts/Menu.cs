using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public GameObject GameMenu;
    public GameObject PauseButton;
    public GameObject RestartButton;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        RestartButton.SetActive(false);
        GameMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        GameMenu.SetActive(true);
        RestartButton.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent = 5000;
        GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent = 200;
        SceneManager.LoadScene(0);
        Resume();
    }
}

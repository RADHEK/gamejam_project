using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject GameMenu;
    public GameObject PauseButton;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
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
        GameMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        GameMenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

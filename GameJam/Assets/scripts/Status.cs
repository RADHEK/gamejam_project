using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int HealthPointMax = 100;
    public int MagicPointMax = 50;
    public int HealthPointCurrent;
    public int MagicPointCurrent;
    public GameObject DeadUI;
    public GameObject PauseButton;
    public GameObject Player;
    public GameObject RestartButton;
    // Use this for initialization
    void Start ()
    {
        HealthPointCurrent = 100;
        MagicPointCurrent = 50;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        IsDead();
	}
    
    void IsDead()
    {
        if(HealthPointCurrent==0)
        {
            DeadPause();
        }
    }

    void IsTruthSight()
    {

    }

    void IsSaint()
    {

    }

    public void DeadPause()
    {
        DeadUI.SetActive(true);
        PauseButton.SetActive(false);
        RestartButton.SetActive(true);
        Time.timeScale = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int HealthPointMax;
    public int MagicPointMax;
    public int HealthPointCurrent;
    public int MagicPointCurrent;
    public bool Saint = false;
    public GameObject DeadUI;
    public GameObject PauseButton;
    public GameObject Player;
    public GameObject RestartButton;
    private float TimeStop;
    private float Timer;
    // Use this for initialization
    void Start()
    {
        TimeStop = 10;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        IsSaint();
        SAINT();
        IsDead();
    }

    void IsDead()
    {
        if (HealthPointCurrent == 0)
        {
            DeadPause();
        }
    }

    void IsSaint()
    {
        if ((MagicPointCurrent >= 25) || Saint)
        {
            if ((Timer -= Time.deltaTime) <= 0)
            {
                if (Input.GetKeyUp(KeyCode.X))
                {

                    Saint = !Saint;
                    if (Saint)
                        Player.transform.position += new Vector3(4000, 0, 0);
                    else Player.transform.position -= new Vector3(4000, 0, 0);
                    Timer = TimeStop;

                }
            }
        }
        
    }

    void SAINT()
    {
        
        if (Saint)
        {
            MagicPointCurrent -= 1;
            HealthPointCurrent += 1;
            if (MagicPointCurrent == 0)
            {
                Saint = false;
                Player.transform.position -= new Vector3(4000, 0, 0);
            }
        }

    }

    public void DeadPause()
    {
        DeadUI.SetActive(true);
        PauseButton.SetActive(false);
        RestartButton.SetActive(true);
        Time.timeScale = 0;
    }
}


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
    public GameObject Light0;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject CanvasN;
    private float TimeStop;
    private float Timer;
    private int Artif;
    // Use this for initialization
    void Start()
    {
        TimeStop = 10;
        Timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
        Artif = GameObject.Find("Player").GetComponent<Player>().Artifacts;
        IsSaint();
        SAINT();
        IsDead();
        Sight();
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
                        Player.transform.position += new Vector3(7195, 0, 0);
                    else Player.transform.position -= new Vector3(7195, 0, 0);
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
            //if(HealthPointCurrent<=200) HealthPointCurrent += 1;
            //加血功能暂时取消了
            if (MagicPointCurrent == 0)
            {
                Saint = false;
                Player.transform.position -= new Vector3(7195, 0, 0);
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
    public void Follow()
    {
        CanvasN.transform.position = new Vector2(Player.transform.position.x+80, Player.transform.position.y);
    }

    public void Sight()
    {
        if (Player.transform.position.x > -2840 && Player.transform.position.x < 4213 && Player.transform.position.y < 4017 && Player.transform.position.y > -2040)
        {
            CanvasN.SetActive(false);
            if (Artif == 0)
                Light0.SetActive(false);

            if (Artif == 1)
            {
                Light1.SetActive(false);
              
            }
            else if (Artif == 2)
            {
                Light2.SetActive(false);
                
            }
            else if (Artif == 3)
            {
                Light3.SetActive(false);
               
            }
         
        }
        else if (Player.transform.position.x > 4355 && Player.transform.position.x < 11408 && Player.transform.position.y < 4017 && Player.transform.position.y > -2040)
        {
            CanvasN.SetActive(true);
            if (Artif==0)
            Light0.SetActive(true);

            if (Artif == 1)
            {
                Light1.SetActive(true);
                Destroy(Light0);
            }
            else if (Artif == 2)
            {
                Light2.SetActive(true);
                Destroy(Light1);
            }
            else if (Artif == 3)
            {
                Light3.SetActive(true);
                Destroy(Light2);
            }
        }
    }
    
}


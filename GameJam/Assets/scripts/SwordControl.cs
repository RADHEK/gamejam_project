using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour {

    private GameObject Player;
    public bool IsAttacking;
    private float TimeStop;
    private float Timer;
    private bool TimeBool;
    // Use this for initialization
    void Start ()
    {
        TimeBool = false;
        IsAttacking = false;
        TimeStop = 0.4f;
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Animator anim = GameObject.Find("Player").GetComponent<Animator>();
        if (anim.GetInteger("Decision") == 2)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -135));
            if (TimeBool)
            {
                this.gameObject.transform.position = new Vector2(Player.transform.position.x + 100, Player.transform.position.y  -100);
                if ((Timer -= Time.deltaTime) < 0)
                {
                    this.gameObject.transform.position = new Vector2(Player.transform.position.x + 100, Player.transform.position.y );
                    IsAttacking = false;
                    TimeBool = false;
                }
            }
            else
                transform.position = new Vector2(Player.transform.position.x + 100, Player.transform.position.y);
            if (Input.GetKeyUp(KeyCode.Z) && !IsAttacking)
            {
                this.gameObject.transform.position = new Vector2(Player.transform.position.x + 100, Player.transform.position.y  -100);
                IsAttacking = true;
                TimeBool = true;
                Timer = TimeStop;
            }
        }
        else if (anim.GetInteger("Decision") == 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 55));
            if (TimeBool)
            {
                this.gameObject.transform.position = new Vector2(Player.transform.position.x + 100, Player.transform.position.y + 100);
                if ((Timer -= Time.deltaTime) < 0)
                {
                    this.gameObject.transform.position = new Vector2(Player.transform.position.x + 100, Player.transform.position.y);
                    IsAttacking = false;
                    TimeBool = false;
                }
            }
            else
                transform.position = new Vector2(Player.transform.position.x + 100, Player.transform.position.y);
            if (Input.GetKeyUp(KeyCode.Z) && !IsAttacking)
            {
                this.gameObject.transform.position = new Vector2(Player.transform.position.x + 100, Player.transform.position.y + 100);
                IsAttacking = true;
                TimeBool = true;
                Timer = TimeStop;
            }
        }
        else if (anim.GetInteger("Decision") == 3)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
            if (TimeBool)
            {
                this.gameObject.transform.position = new Vector2(Player.transform.position.x-80 , Player.transform.position.y +50);
                if ((Timer -= Time.deltaTime) < 0)
                {
                    this.gameObject.transform.position = new Vector2(Player.transform.position.x+20, Player.transform.position.y+50);
                    IsAttacking = false;
                    TimeBool = false;
                }
            }
            else
                transform.position = new Vector2(Player.transform.position.x +20, Player.transform.position.y + 50);
            if (Input.GetKeyUp(KeyCode.Z) && !IsAttacking)
            {
                this.gameObject.transform.position = new Vector2(Player.transform.position.x - 80, Player.transform.position.y + 50);
                IsAttacking = true;
                TimeBool = true;
                Timer = TimeStop;
            }
        }
        else if (anim.GetInteger("Decision") == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45));
            if (TimeBool)
            {
                this.gameObject.transform.position = new Vector2(Player.transform.position.x + 120, Player.transform.position.y + 50);
                if ((Timer -= Time.deltaTime) < 0)
                {
                    this.gameObject.transform.position = new Vector2(Player.transform.position.x + 20, Player.transform.position.y+50);
                    IsAttacking = false;
                    TimeBool = false;
                }
            }
            else
                transform.position = new Vector2(Player.transform.position.x + 20, Player.transform.position.y+50);
            if (Input.GetKeyUp(KeyCode.Z) && !IsAttacking)
            {
                this.gameObject.transform.position = new Vector2(Player.transform.position.x + 120, Player.transform.position.y + 50);
                IsAttacking = true;
                TimeBool = true;
                Timer = TimeStop;
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Artifacts = 0;
    private int HealthGet = 50, MagicGet = 500;
    private int MaxHP, CurHP, MaxMP, CurMP;
    public float horizontal, vertical;
    public float Player_Speed;
    public Rigidbody2D Player_rb;
    private float TimeStop, Timer;
    private int Bounce;
    bool IsFacingRight = true;
    Animator Anim;
    private float timeBtwAttack;
    public float startTimeBtAttack;
    private bool IsBoost;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public bool IsHurt;
    // Use this for initialization
    void Start()
    {
        IsBoost = false;
        MaxMP = GameObject.Find("Status").GetComponent<Status>().MagicPointMax;
        MaxHP = GameObject.Find("Status").GetComponent<Status>().HealthPointMax;
        Player_rb = GetComponent<Rigidbody2D>();
        TimeStop = 0.3f;
        Timer = 0;
        Anim = this.GetComponent<Animator>();
        
    }


    // Update is called once per frame

    void FixedUpdate()
    {
        Anim.SetBool("Hurt", false);
        BoostUp();
        if ((Timer -= Time.deltaTime) >= 0)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Bounce, 0), ForceMode2D.Force);
        //AnimationPlayerMove();
        Move();
        CurHP = GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent;
        CurMP = GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent;
        if (Player_rb.velocity.x > 0 && !IsFacingRight) Flip();
        if (Player_rb.velocity.x < 0 && IsFacingRight) Flip();
        //attack function
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Anim.SetBool("IsAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyControll>().TakeDamage(damage);

                }
                timeBtwAttack = startTimeBtAttack;
            }
            else
            {
                IsHurt = false;
                Anim.SetBool("IsAttacking", false);
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Artifacts")
        {
            Artifacts += 1;
            Destroy(collider2D.gameObject);
        }
        else if (collider2D.tag == "HealthGet")
        {
            GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent = (CurHP + HealthGet) > MaxHP ? MaxHP : (CurHP + HealthGet);
            Destroy(collider2D.gameObject);
        }
        else if (collider2D.tag == "MagicGet")
        {
            GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent = (CurMP + MagicGet) > MaxMP ? MaxMP : (CurMP + MagicGet);
            Destroy(collider2D.gameObject);
        }
        else if (collider2D.tag == "Enemy")
        {
            GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent -= 50;
            Timer = TimeStop;
            Anim.SetBool("Hurt", true);
            if (collider2D.gameObject.GetComponent<EnemyControll>().IsFacingRight)
                Bounce = 500000;
            else
                Bounce = -500000;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPos.position, attackRange);
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Player_rb.velocity = new Vector2(horizontal * Player_Speed, vertical * Player_Speed);
        if (horizontal == 0 && vertical == 0)
            Anim.SetBool("IsWalking", false);
        else Anim.SetBool("IsWalking", true);

    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector2 Temp = transform.localScale;
        Temp.x *= -1;
        transform.localScale = Temp;
    }

    private void BoostUp()
    {
        if (GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            if (!IsBoost)
            {
                IsBoost = true;
                Player_Speed *= 2;
            }
            GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent -= 5;
        }
        else
        {
            if(IsBoost)
            {
                IsBoost = false;
                Player_Speed /= 2;
            }
        }
    }
}



    /*
    void AnimationPlayerMove()
    {
        Animator Animator = this.GetComponent<Animator>();
        
        if (!anim.GetBool("StillSwitch"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetInteger("Decision", 0);
                anim.SetInteger("IsStill", 0);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetInteger("Decision", 2);
                anim.SetInteger("IsStill", 2);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetInteger("Decision", 3);
                anim.SetInteger("IsStill", 3);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetInteger("Decision", 1);
                anim.SetInteger("IsStill", 1);
            }
            
        }
        
    }
*/



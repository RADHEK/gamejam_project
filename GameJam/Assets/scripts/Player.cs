using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Artifacts = 0;
    private int HealthGet = 50;
    private int MagicGet = 50;
    private int MaxHP;
    private int CurHP;
    private int MaxMP;
    private int CurMP;
    public float horizontal, vertical;
    public float Player_Speed;
    public Rigidbody2D Player_rb;
    private float TimeStop;
    private float Timer;
    private int Bounce;
    //Vector2 movement;
    //bool IsFacingRight = true;

    // Use this for initialization
    void Start()
    {

        MaxMP = GameObject.Find("Status").GetComponent<Status>().MagicPointMax;
        MaxHP = GameObject.Find("Status").GetComponent<Status>().HealthPointMax;
        Player_rb = GetComponent<Rigidbody2D>();
        TimeStop = 0.3f;
        Timer = 0;
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
            GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent = (CurHP + HealthGet) > MaxHP ? MaxHP : (CurHP + 50);
            Destroy(collider2D.gameObject);
        }
        else if (collider2D.tag == "MagicGet")
        {
            GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent = (CurMP + MagicGet) > MaxMP ? MaxMP : (CurMP + 50);
            Destroy(collider2D.gameObject);
        }
        else if (collider2D.tag == "Enemy")
        {
            GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent -= 50;
            Timer = TimeStop;
            if (collider2D.gameObject.GetComponent<EnemyControll>().IsFacingRight)
                Bounce = 500000;
            else
                Bounce = -500000;
        }
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        
        if((Timer-=Time.deltaTime)>=0)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Bounce,0 ), ForceMode2D.Force);
        AnimationPlayerMove();
        Move();
        CurHP = GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent;
        CurMP = GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent;
        //if (Player_rb.velocity.x > 0 && !IsFacingRight) Flip();
        //if (Player_rb.velocity.x < 0 && IsFacingRight) Flip();
    }

    void AnimationPlayerMove()
    {
        Animator anim = this.GetComponent<Animator>();
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

    private void Move()
    {
        Animator anim = this.GetComponent<Animator>();
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal == 0 && vertical == 0)
            anim.SetBool("StillSwitch", true);
        else
            anim.SetBool("StillSwitch", false);
        Player_rb.velocity = new Vector2(horizontal * Player_Speed, vertical * Player_Speed);
    }

    /*private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector2 Temp = transform.localScale;
        Temp.x *= -1;
        transform.localScale = Temp;
    }*/
}


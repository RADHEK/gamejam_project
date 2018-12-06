using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int Artifacts = 0;
    private int HealthGet = 50;
    private int MagicGet = 50;
    private int MaxHP;
    private int CurHP;
    private int MaxMP;
    private int CurMP;
    public float horizontal, vertical;
    public float Player_Speed;
    public Rigidbody2D Player_rb;
    //Vector2 movement;
    //bool IsFacingRight = true;

    // Use this for initialization
    void Start()
    {
        MaxMP = GameObject.Find("Status").GetComponent<Status>().MagicPointMax;
        MaxHP = GameObject.Find("Status").GetComponent<Status>().HealthPointMax;
        Player_rb = GetComponent<Rigidbody2D>();
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
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetInteger("Decision", 0);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetInteger("Decision", 2);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetInteger("Decision", 3);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetInteger("Decision", 1);
        }
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
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


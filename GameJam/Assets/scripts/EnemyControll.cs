using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{

    private Transform Player;
    public float EnemyMoveSpeed;
    public float ChaseDistance;
    public Vector2 PatrolA, PatrolB;
    public Rigidbody2D Enemy1;
    private float Distance;
    public bool IsFacingRight = true;
    public Vector2 Target;
    public int HealthPoint;
    private bool IsDead = false;
    private float Timer;
    // Use this for initialization
    void Start()
    {
        Timer = 2;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Target = PatrolA;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsEmitated();
        if (!IsDead)
        {
            Distance = Vector2.Distance(Player.position, Enemy1.transform.position);
            if (Distance < ChaseDistance)
            {
                Chase();
                if (Player.position.x > Enemy1.transform.position.x && !IsFacingRight)
                    Flip();
                if (Player.position.x < Enemy1.transform.position.x && IsFacingRight)
                    Flip();
            }
            else
            {
                Patrol();
                if (Target.x > Enemy1.transform.position.x && !IsFacingRight)
                    Flip();
                if (Target.x < Enemy1.transform.position.x && IsFacingRight)
                    Flip();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Sword" && GameObject.Find("Sword").GetComponent<SwordControl>().IsAttacking)
        {
            HealthPoint -= 50;
        }
    }

    private void Chase()
    {

        transform.position = Vector2.MoveTowards(transform.position, Player.position, EnemyMoveSpeed * Time.deltaTime);

    }

    private void Patrol()
    {
        if (Vector2.Distance(Target, Enemy1.transform.position) > 0.001)
        {
            Enemy1.transform.position = Vector2.MoveTowards(transform.position, Target, EnemyMoveSpeed * Time.deltaTime);
            if (Vector2.Distance(Target, Enemy1.transform.position) < 0.001)
            {
                if (Target == PatrolA)
                    Target = PatrolB;
                else Target = PatrolA;

            }
        }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector2 Temp = transform.localScale;
        Temp.x *= -1;
        transform.localScale = Temp;
    }

    private void IsEmitated()
    {
        if (HealthPoint <= 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            IsDead = true;
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Timer -= Time.deltaTime;
            if (Timer< 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

}



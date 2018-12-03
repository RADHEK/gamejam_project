using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{

    public Transform Player;
    public float Enemy_MoveSpeed;
    public Rigidbody2D Enemy1;
    private float Distance;
    bool IsFacingRight = true;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Chase();
        if (Player.position.x > Enemy1.transform.position.x && !IsFacingRight)
            Flip();
        if (Player.position.x < Enemy1.transform.position.x && IsFacingRight)
            Flip();
    }

    private void Chase()
    {
        Distance = Vector2.Distance(Player.position, Enemy1.transform.position);
        if (Distance < 500)
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Enemy_MoveSpeed * Time.deltaTime);

    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector2 Temp = transform.localScale;
        Temp.x *= -1;
        transform.localScale = Temp;
    }


}


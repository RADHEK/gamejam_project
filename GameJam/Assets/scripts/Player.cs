using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float horizontal,vertical;
    public float Player_Speed;
    public Rigidbody2D Player_rb;
    Vector2 movement;

	// Use this for initialization
	void Start ()
    {
        Player_rb = GetComponent<Rigidbody2D>();
	}
    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.name == "Enemy_test")
        {
            GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent -= 1;
        }
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Player_rb.velocity = new Vector2(horizontal * Player_Speed, vertical*Player_Speed);
    }
}


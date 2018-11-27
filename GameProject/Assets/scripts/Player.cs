using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float horizontal,vertical;
    public float Player_Speed;
    public Rigidbody2D Player_rb;
    Vector2 movement;

	// Use this for initialization
	void Start () {
        Player_rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Player_rb.velocity = new Vector2(horizontal * Player_Speed, vertical*Player_Speed);
    }
 
}

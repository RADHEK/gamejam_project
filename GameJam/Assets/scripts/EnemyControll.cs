using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour {

    public Transform Player;
    public float Enemy_MoveSpeed;
    public Rigidbody2D Enemy1;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position=Vector2.MoveTowards(transform.position, Player.position, Enemy_MoveSpeed * Time.deltaTime);
	}
}

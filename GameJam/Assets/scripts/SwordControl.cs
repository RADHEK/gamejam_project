using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour {

    private GameObject Player;
    public bool IsAttacking;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Player.transform.position.x+100, Player.transform.position.y+50, 0);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.RotateAround(Player.transform.position, new Vector3(0, 0, 1), -45  );
            IsAttacking = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            transform.RotateAround(Player.transform.position, new Vector3(0, 0, 1), 45  );
            IsAttacking = false;
        }

    }
}

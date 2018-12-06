using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {

        if (Player.transform.position.x > -1500 && Player.transform.position.x < 1500 && Player.transform.position.y < 1500 && Player.transform.position.y > -1500)
        {
            if (Player.transform.position.x > -629 && Player.transform.position.x < 629 && Player.transform.position.y < 1018 && Player.transform.position.y > -1018)
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);
            if (Player.transform.position.x > 629)
            {
                if (Player.transform.position.y > 1018)
                    transform.position = new Vector3(629, 1018, -1);
                else if (Player.transform.position.y < -1018)
                    transform.position = new Vector3(629, -1018, -1);
                else transform.position = new Vector3(629, Player.transform.position.y, -1);
            }
            if (Player.transform.position.x < -629)
            {
                if (Player.transform.position.y > 1018)
                    transform.position = new Vector3(-629, 1018, -1);
                else if (Player.transform.position.y < -1018)
                    transform.position = new Vector3(-629, -1018, -1);
                else transform.position = new Vector3(-629, Player.transform.position.y, -1);
            }
            if (Player.transform.position.y > 1018)
            {
                if (Player.transform.position.x > 629)
                    transform.position = new Vector3(629, 1018, -1);
                else if (Player.transform.position.x < -629)
                    transform.position = new Vector3(-629, 1018, -1);
                else transform.position = new Vector3(Player.transform.position.x, 1018, -1);
            }
            if (Player.transform.position.y < -1018)
            {
                if (Player.transform.position.x > 629)
                    transform.position = new Vector3(629, -1018, -1);
                else if (Player.transform.position.x < -629)
                    transform.position = new Vector3(-629, -1018, -1);
                else transform.position = new Vector3(Player.transform.position.x, -1018, -1);
            }
        }

        if (Player.transform.position.x > 2500 && Player.transform.position.x < 5500 && Player.transform.position.y < 1500 && Player.transform.position.y > -1500)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);
            if (Player.transform.position.x > 4629)
            {
                if (Player.transform.position.y > 1018)
                    transform.position = new Vector3(4629, 1018, -1);
                else if (Player.transform.position.y < -1018)
                    transform.position = new Vector3(4629, -1018, -1);
                else transform.position = new Vector3(4629, Player.transform.position.y, -1);
            }
            if (Player.transform.position.x < 3371)
            {
                if (Player.transform.position.y > 1018)
                    transform.position = new Vector3(3371, 1018, -1);
                else if (Player.transform.position.y < -1018)
                    transform.position = new Vector3(3371, -1018, -1);
                else transform.position = new Vector3(3371, Player.transform.position.y, -1);
            }
            if (Player.transform.position.y > 1018)
            {
                if (Player.transform.position.x > 4629)
                    transform.position = new Vector3(4629, 1018, -1);
                else if (Player.transform.position.x < 3371)
                    transform.position = new Vector3(3371, 1018, -1);
                else transform.position = new Vector3(Player.transform.position.x, 1018, -1);
            }
            if (Player.transform.position.y < -1018)
            {
                if (Player.transform.position.x > 4629)
                    transform.position = new Vector3(4629, -1018, -1);
                else if (Player.transform.position.x < 3371)
                    transform.position = new Vector3(3371, -1018, -1);
                else transform.position = new Vector3(Player.transform.position.x, -1018, -1);
            }
        }
    }
}




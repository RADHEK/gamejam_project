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

        if (Player.transform.position.x > -2840 && Player.transform.position.x < 4213 && Player.transform.position.y < 4017 && Player.transform.position.y > -2040)
        {
            //if (Player.transform.position.x > -629 && Player.transform.position.x < 629 && Player.transform.position.y < 1018 && Player.transform.position.y > -1018)
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);
            if (Player.transform.position.x > 3058)
            {
                if (Player.transform.position.y > 3435)
                    transform.position = new Vector3(3058, 3435, -1);
                else if (Player.transform.position.y < -1460)
                    transform.position = new Vector3(3058, -1460, -1);
                else transform.position = new Vector3(3058, Player.transform.position.y, -1);
            }
            if (Player.transform.position.x < -1690)
            {
                if (Player.transform.position.y > 3435)
                    transform.position = new Vector3(-1690, 3435, -1);
                else if (Player.transform.position.y < -1460)
                    transform.position = new Vector3(-1690, -1460, -1);
                else transform.position = new Vector3(-1690, Player.transform.position.y, -1);
            }
            if (Player.transform.position.y > 3435)
            {
                if (Player.transform.position.x > 3058)
                    transform.position = new Vector3(3058, 3435, -1);
                else if (Player.transform.position.x < -1690)
                    transform.position = new Vector3(-1690, 3435, -1);
                else transform.position = new Vector3(Player.transform.position.x, 3435, -1);
            }
            if (Player.transform.position.y < -1460)
            {
                if (Player.transform.position.x > 3058)
                    transform.position = new Vector3(3058, -1460, -1);
                else if (Player.transform.position.x < -1690)
                    transform.position = new Vector3(-1690, -1460, -1);
                else transform.position = new Vector3(Player.transform.position.x, -1460, -1);
            }
        }

        if (Player.transform.position.x > 4355 && Player.transform.position.x < 11408 && Player.transform.position.y < 4017 && Player.transform.position.y > -2040)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);
            if (Player.transform.position.x > 10253)
            {
                if (Player.transform.position.y > 3435)
                    transform.position = new Vector3(10253, 3435, -1);
                else if (Player.transform.position.y < -1460)
                    transform.position = new Vector3(10253, -1460, -1);
                else transform.position = new Vector3(10253, Player.transform.position.y, -1);
            }
            if (Player.transform.position.x < 5505)
            {
                if (Player.transform.position.y > 3435)
                    transform.position = new Vector3(-1690, 3435, -1);
                else if (Player.transform.position.y < -1460)
                    transform.position = new Vector3(-1690, -1460, -1);
                else transform.position = new Vector3(-1690, Player.transform.position.y, -1);
            }
            if (Player.transform.position.y > 3435)
            {
                if (Player.transform.position.x > 10253)
                    transform.position = new Vector3(10253, 3435, -1);
                else if (Player.transform.position.x < 5505)
                    transform.position = new Vector3(5505, 3435, -1);
                else transform.position = new Vector3(Player.transform.position.x, 3435, -1);
            }
            if (Player.transform.position.y < -1460)
            {
                if (Player.transform.position.x > 10253)
                    transform.position = new Vector3(10253, -1460, -1);
                else if (Player.transform.position.x < 5505)
                    transform.position = new Vector3(5505, -1460, -1);
                else transform.position = new Vector3(Player.transform.position.x, -1460, -1);
            }
        }
    }
}




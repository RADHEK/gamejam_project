using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject Enemy_Prefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0))
            Instantiate(Enemy_Prefab, Vector3.zero, Quaternion.identity);
    }
}

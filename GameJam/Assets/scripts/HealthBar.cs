using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthPoint;
	// Use this for initialization
	void Start ()
    {
        HealthPoint.maxValue= GameObject.Find("Status").GetComponent<Status>().HealthPointMax;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        HealthPoint.value = GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent;
    }
}

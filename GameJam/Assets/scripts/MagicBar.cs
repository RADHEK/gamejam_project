using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{
    public Slider MagicPoint;
	// Use this for initialization
	void Start ()
    {
        MagicPoint.maxValue= GameObject.Find("Status").GetComponent<Status>().MagicPointMax;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        MagicPoint.value = GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent;
    }
}

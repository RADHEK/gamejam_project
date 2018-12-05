using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public int Artifacts = 0;
    public int HealthGet = 50;
    public int MagicGet = 50;
    public int MaxHP= GameObject.Find("Status").GetComponent<Status>().HealthPointMax;
    public int CurHP= GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent;
    public int MaxMP= GameObject.Find("Status").GetComponent<Status>().MagicPointMax;
    public int CurMP= GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent;
    public GameObject GBArtifacts;
    public GameObject GBMagic;
    public GameObject GBHealthGet;
    // Use this for initialization
    void Start ()
    {
        Artifacts = 0;
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Artifacts")
        {
            Artifacts += 0;
            GBArtifacts.SetActive(false);
        }
        else if(collider2D.tag=="HealthGet")
        {
            GameObject.Find("Status").GetComponent<Status>().HealthPointCurrent=(MaxHP+HealthGet)>=MaxHP?MaxHP:(CurHP+50);
        }
        else if(collider2D.tag == "MagicGet")
        {
            GameObject.Find("Status").GetComponent<Status>().MagicPointCurrent = (MaxMP + MagicGet) >= MaxMP ? MaxMP : (CurMP + 50);
        }
    }
}

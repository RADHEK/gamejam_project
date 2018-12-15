using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CD : MonoBehaviour
{
    public float coldTime = 10;//技能的冷却时间
    private float currentTime = 0;//当前冷却时间

    public Text skillCDText;
    public Image Mask;
    public Image skillBtn;
    

    void Awake()
    {
        Mask.fillAmount = 0;
        skillCDText.text = null;
    }

    void Update()
    {
        SkillTimeCalculator();
    }

    public void UseSkill()
    {
        currentTime = coldTime;
        Mask.fillAmount = 1;
        skillCDText.text = coldTime.ToString();
        skillBtn.enabled = false;
    }

    private void SkillTimeCalculator()
    {
        if (currentTime <= 0)
        {
            Mask.fillAmount = 0;
            skillCDText.text = null;
            skillBtn.enabled = true;
            return;
        }
        else
        {
            currentTime -= Time.deltaTime;
            var value = currentTime / coldTime;
            Mask.fillAmount = value;
            skillCDText.text = ((int)currentTime + 1).ToString();
        }
    }
}



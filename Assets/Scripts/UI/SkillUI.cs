using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public static SkillUI skill1 { get; private set; }
    public static SkillUI skill2 { get; private set; }

    public Image bar;
    float originalSize;


    public bool isSkill1;

    void Awake()
    {
        if (isSkill1)
        {
            skill1 = this;
        }
        else
        {
            skill2 = this;
        }
    }

    void Start()
    {
        originalSize = bar.rectTransform.rect.width;

    }

    // Update is called once per frame
    public void SetValue(float value)
    {
        bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}

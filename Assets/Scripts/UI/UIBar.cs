using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    public static UIBar health { get; private set; }
    public static UIBar mana { get; private set; }

    public Image bar;
    float originalSize;

    public bool isHealth;

    void Awake()
    {
        if (isHealth)
        {
            health = this;
        }
        else
        {
            mana = this;
        }
    }

    void Start()
    {
        originalSize = bar.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}

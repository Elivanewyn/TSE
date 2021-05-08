using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentExp = 0;
    public int currentPoints = 0;
    public Text pointsText;
    public Image pointsImage;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        pointsText.text ="" + currentPoints;
        if(currentPoints < 1)
        {
            pointsImage.color = new Color(1, 1, 1, 1);
        }
        else { pointsImage.color = new Color(1, 1, 0, 1); }

        if(currentExp >= 5)
        {
            FindObjectOfType<AudioManager>().PlaySound("LevelUp");
            currentExp -= 5;
            currentPoints++;
        }

        //if(Input.GetKeyDown(KeyCode.V))
        //{
        //    currentExp++;
        //}
    }
}

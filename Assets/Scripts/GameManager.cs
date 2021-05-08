using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentExp = 0;
    public int currentPoints = 0;
    public Image pointsImage;
    public Text pointsText;
    private bool exists;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name != "TitleScene" && SceneManager.GetActiveScene().name != "DeathScene")
        {
            pointsImage = GameObject.Find("Frame_Find").GetComponent<Image>();
            pointsText = GameObject.Find("Text_Find").GetComponent<Text>();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "TitleScene" && SceneManager.GetActiveScene().name != "DeathScene")
        {
            pointsText.text = "" + currentPoints;
            if (currentPoints < 1)
            {
                pointsImage.color = new Color(1, 1, 1, 1);
            }
            else { pointsImage.color = new Color(1, 1, 0, 1); }

            if (currentExp >= 5)
            {
                FindObjectOfType<AudioManager>().PlaySound("LevelUp");
                currentExp -= 5;
                currentPoints++;
            }
        }

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    currentExp++;
        //}
    }
}

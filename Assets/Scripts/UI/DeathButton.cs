using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathButton : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Button").GetComponentInChildren<Text>().text = "Restart";
    }
    public void ManageScene()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}

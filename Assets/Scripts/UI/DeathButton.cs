using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathButton : MonoBehaviour
{
    public GameObject respawn;
    public GameObject congrats;
    CanScript canScript;
    void Start()
    {
        GameObject.Find("Button").GetComponentInChildren<Text>().text = "Restart";
        canScript = GameObject.Find("Canvas").GetComponent<CanScript>();
    }

    private void Update()
    {
        if(CanScript.bossDead == true)
        {
            respawn.SetActive(false);
            congrats.SetActive(true);
        }
    }
    public void ManageScene()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDontDestroyScript : MonoBehaviour
{
    private bool exists = false;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "TitleScene" || SceneManager.GetActiveScene().name == "DeathScene")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        //if (!exists)
        //{
        //    exists = true;
        DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDontDestroyScript : MonoBehaviour
{
    private bool exists = false;

    void Awake()
    {
        if (!exists)
        {
            Debug.Log("Don't Destroy");
            exists = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
}

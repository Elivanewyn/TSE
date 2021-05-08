using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDontDestroyScript : MonoBehaviour
{
    private bool exists = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (!exists)
        {
            Debug.Log("dont destroy");
            exists = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

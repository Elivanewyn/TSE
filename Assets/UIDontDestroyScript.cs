using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDontDestroyScript : MonoBehaviour
{
    private static bool exists;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

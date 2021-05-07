using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{

    private PlayerMovement thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        thePlayer.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

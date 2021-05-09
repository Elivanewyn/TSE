using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    // find boss
    private angelCombat theBoss;
    private bool isDead;
    private int bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        theBoss = FindObjectOfType<angelCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }
}

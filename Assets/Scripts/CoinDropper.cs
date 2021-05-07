using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void coinDrop()
    {
        Instantiate(coin, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
    }
}
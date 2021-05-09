using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    public GameObject coin;

    public void coinDrop()
    {
        Instantiate(coin, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
    }
}
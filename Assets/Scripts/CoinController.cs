using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public ShopController shopController;

    void Start()
    {
        shopController = GameObject.Find("UIController").GetComponent<ShopController>();

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("Coin");
            System.Random rnd = new System.Random();
            int rndNum = rnd.Next(3, 6);
            for (int x = 0; x < rndNum; x++)
            {
                ShopController.coinQuantity += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
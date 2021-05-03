using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public ShopController shopController;

    void Start()
    {
        //ShopController shopController = Canvas.GetComponent<ShopController>();

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shopController.coinQuantity += 1;
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string newDialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogBox.activeInHierarchy && playerInRange == false)
        {
            dialogBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            {
                dialogBox.SetActive(true);
                dialogText.text = newDialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public static bool isOpen = false;
    public GameObject ShopMenu;

    public RawImage m_RawImage;
    public Texture[] textureArray;
    public TextMeshProUGUI potionText;
    public int[] potionQuantityArray;

    public TextMeshProUGUI coinText;
    public int coinQuantity;

    public TextMeshProUGUI WeaponLvOneCost;
    public TextMeshProUGUI WeaponLvOneText;

    public TextMeshProUGUI WeaponLvTwoCost;
    public TextMeshProUGUI WeaponLvTwoText;

    public TextMeshProUGUI WeaponLvThreeCost;
    public TextMeshProUGUI WeaponLvThreeText;

    private float timeStamp;
    int x = 0;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                CloseShop();
            }
            else
            {
                OpenShop();
            }
        }

        if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.E)))
        {
            if (isOpen)
            {
                CloseShop();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (x != 0)
            {
                if (timeStamp <= Time.time)
                {
                    Potion(-1);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (x != 3)
            {
                if (timeStamp <= Time.time)
                {
                    Potion(1);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        coinText.text = $"{coinQuantity}";
    }

    void CloseShop()
    {
        ShopMenu.SetActive(false);
        isOpen = false;
    }

    void OpenShop()
    {
        ShopMenu.SetActive(true);
        isOpen = true;
    }

    void Potion(int y)
    {
        m_RawImage.texture = textureArray[x + y];
        potionText.text = $"{potionQuantityArray[x + y]}";
        x += y;
        timeStamp = (float)(Time.time + 0.2);
    }

    public void GenericPotion(int potionNumber)
    {
        if (coinQuantity >= 10)
        {
            coinQuantity -= 10;
            potionQuantityArray[potionNumber] += 1;
            m_RawImage.texture = textureArray[potionNumber];
            potionText.text = $"{potionQuantityArray[potionNumber]}";
            x = potionNumber;
        }
        else
        {
            NotEnoughMoney();
        }
    }

    public void LvOneWeapon()
    {
        if (WeaponLvOneCost.text != "")
        {
            if (coinQuantity >= 250)
            {
                coinQuantity -= 50;
                WeaponLvOneCost.text = "";
                WeaponLvOneText.text = "Already Owned";
                //add in code for giving the user the weapon they purchased
            }
            else
            {
                NotEnoughMoney();
            }
        }
        else
        {
            AlreadyOwned();
        }
    }

    public void LvTwoWeapon()
    {
        if (WeaponLvTwoCost.text != "")
        {
            if (coinQuantity >= 250)
            {
                coinQuantity -= 50;
                WeaponLvTwoCost.text = "";
                WeaponLvTwoText.text = "Already Owned";
                //add in code for giving the user the weapon they purchased
            }
            else
            {
                NotEnoughMoney();
            }
        }
        else
        {
            AlreadyOwned();
        }
    }

    public void LvThreeWeapon()
    {
        if(WeaponLvThreeCost.text != "")
        {
            if (coinQuantity >= 250)
            {
                coinQuantity -= 50;
                WeaponLvThreeCost.text = "";
                WeaponLvThreeText.text = "Already Owned";
                //add in code for giving the user the weapon they purchased
            }
            else
            {
                NotEnoughMoney();
            }
        }
        else
        {
            AlreadyOwned();
        }
    }

    public void AlreadyOwned()
    {
        //add a nofication of some sort to tell user they have already purchased this weapon
    }

    void NotEnoughMoney()
    {
        //add a nofication of some sort to tell user they dont have enough money
    }
}

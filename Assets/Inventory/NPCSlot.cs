using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using TMPro.Examples;
using JetBrains.Annotations;

public class NPCSlot : MonoBehaviour
{

    private InventoryController inventory;
    private PlayerController player;

    public Image itmeImage;
    public Text itemName;
    public Text itemPrice;
    public Text itemAmount;

    public GameObject itemToBuy;
    public int _ItemAmount;
    public Text buyPriceText;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
        player = FindObjectOfType<PlayerController>();
        itemName.text = itemToBuy.GetComponentInChildren<spawn>().itemName;
        itmeImage.sprite = itemToBuy.GetComponent<Image>().sprite;
        buyPriceText.text = itemToBuy.GetComponentInChildren<spawn>().ItemPrice + " Gold";
    }

    // Update is called once per frame
    void Update()
    {
        itemAmount.text = " " + _ItemAmount.ToString();
    }

    public void Buy()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slot>().amount < 5 && player.Gold >= itemToBuy.GetComponentInChildren<spawn>().ItemPrice && _ItemAmount > 0)
            {
                if (itemName.text == inventory.slots[i].transform.GetComponentInChildren<spawn>().itemName)
                {
                    _ItemAmount -= 1;
                    inventory.slots[i].GetComponent<Slot>().amount += 1;
                    player.Gold -= itemToBuy.GetComponentInChildren<spawn>().ItemPrice;
                    break;
                }
            }
            else if (inventory.isFull[i] == false && player.Gold >= itemToBuy.GetComponentInChildren<spawn>().ItemPrice && _ItemAmount > 0)
            {
                _ItemAmount -= 1;
                player.Gold -= itemToBuy.GetComponentInChildren<spawn>().ItemPrice;
                inventory.slots[i].GetComponent<Slot>().ItemName.text = itemName.text;
                inventory.isFull[i] = true;
                Instantiate(itemToBuy, inventory.slots[i].transform, false);
                inventory.slots[i].GetComponent<Slot>().amount += 1;
                break;
            }
        }
    }

    public void Sell()
    {
        for(int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].transform.GetComponent<Slot>().amount != 0)
            {
                if(itemName.text == inventory.slots[i].transform.GetComponentInChildren<spawn>().itemName)
                {
                    _ItemAmount += 1;
                    inventory.slots[i].GetComponent<Slot>().amount -= 1;
                    player.Gold += itemToBuy.GetComponentInChildren<spawn>().ItemPrice / 2;
                    if (inventory.slots[i].GetComponent<Slot>().amount == 0)
                    {
                        inventory.slots[i].GetComponent<Slot>().ItemName.text = string.Empty;
                        GameObject.Destroy(inventory.slots[i].transform.GetComponentInChildren<spawn>().gameObject);
                    }
                    break;
                }
            }
        }
    }
}

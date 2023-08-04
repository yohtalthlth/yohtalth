using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private InventoryController inventory;
    public int i;
    public Text amountText;
    public Text ItemName;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        amountText.text = amount.ToString();

        if(amount > 1)
        {
            transform.GetChild(1).GetComponent<Text>().enabled = true;
        }
        else
        {
            transform.GetChild(1).GetComponent<Text>().enabled = false;
        }


        if(transform.childCount == 9)
        {
            inventory.isFull[i] = false;
        }
    }
}

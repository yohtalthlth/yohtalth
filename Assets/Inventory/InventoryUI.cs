using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject shop;
    public Button closeShop;
    public bool isShopAcitve;
    bool activeInventory = false;
    bool activeShop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            activeInventory= !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            activeShop = !activeShop;
            shop.SetActive(activeShop);
        }
    }
}
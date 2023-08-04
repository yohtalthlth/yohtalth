using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite imageOn;
    public Sprite imageOff;
    public bool isChestOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        if (isChestOpen)
        {
            GetComponent<SpriteRenderer>().sprite = imageOn;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = imageOff;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (isChestOpen)
            {
                isChestOpen = false;
                GetComponent<SpriteRenderer>().sprite = imageOff;
            }
            else
            {
                isChestOpen = true;
                GetComponent<SpriteRenderer>().sprite = imageOn;
            }
        }
    }
}

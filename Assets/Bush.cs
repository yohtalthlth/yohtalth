using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditorInternal;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private bool state;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        state = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(state == true)
            {
                Player.SetActive(false);
                state = false;
            }
            else
            {
                Player.SetActive(true);
                state = true;
            }
        }
    }
}

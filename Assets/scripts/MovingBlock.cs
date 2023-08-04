using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float moveX = 0.0f;
    public float moveY = 0.0f;
    public float times = 0.0f;
    public float weight = 0.0f;
    public bool isMovewhenOn = false;

    public bool isCanMove = true;
    float perDX;
    float perDY;
    float misDX;
    Vector3 defPOS;
    bool isReverse = false;
    // Start is called before the first frame update
    void Start()
    {
        defPOS = transform.position;
        float timestep = Time.fixedDeltaTime;
        perDX = moveX / (1.0f / timestep * times);
        misDX = moveX / (-1.0f /  timestep * times);
        perDY = moveY / (1.0f / timestep * times);
        if(isMovewhenOn)
        {
            isCanMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(isCanMove)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            bool endX = false;
            bool endY = false;
            if(isReverse)
            {
                if((perDX >= 0.0f && x <= defPOS.x) || (perDX < 0.0f && x >= defPOS.x))
                {
                    endX = true;
                }
                if((misDX <= 0.0f && x >= defPOS.x) || (misDX > 0.0f && x <= defPOS.x))
                {
                    endX = true;
                }
                if((perDY >= 0.0f && y <= defPOS.y) || (perDY < 0.0f && y >= defPOS.y))
                {
                    endY = true;
                }
                transform.Translate(new Vector3(x-perDX, y-perDY, defPOS.z));
            }
            else
            {
                if((perDX >= 0.0f && x >= defPOS.x + moveX) || (perDX < 0.0f && x <= defPOS .x + moveX))
                {
                    endX = true;
                }
                if ((misDX <= 0.0f && x <= defPOS.x) || (misDX > 0.0f && x >= defPOS.x))
                {
                    endX = true;
                }
                if ((perDY >= -0.0f && y >= defPOS.y + moveY) || (perDY < 0.0f && y <= defPOS.y + moveY)){
                    endY = true;
                }
                Vector3 v = new Vector3(perDX, perDY, defPOS.z);
                Vector3 v2 = new Vector3(misDX, perDY, defPOS.z);
                transform.Translate(v);
                transform.Translate(v2);
            }

            if(endX && endY)
            {
                if (isReverse)
                {
                    transform.position = defPOS;
                }
                isReverse = !isReverse;
                isCanMove = false;
                if(isMovewhenOn == false)
                {
                    Invoke("Move", weight);
                }
            }
        }
    }

    public void Move()
    {
        isCanMove = true;
    }

    public void Stop()
    {
        isCanMove= false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCanMove = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}

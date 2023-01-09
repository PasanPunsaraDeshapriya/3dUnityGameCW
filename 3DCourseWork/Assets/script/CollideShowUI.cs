using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideShowUI : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    
    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag=="Player")
        {
            uiObject.SetActive(true);

        }
        
    }
    void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);

        }

    }
}

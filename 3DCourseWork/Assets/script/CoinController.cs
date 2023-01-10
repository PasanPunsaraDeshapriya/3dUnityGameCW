using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int rotateSpeed;

    void Start()
    {
        rotateSpeed = 2;
    }



    public GameObject coin;
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0,Space.World);
    }

    void OnTriggerEnter(Collider Player)
    {

        if (Player.gameObject.tag == "Player")
        {
            coin.SetActive(false);

        }




    }
}

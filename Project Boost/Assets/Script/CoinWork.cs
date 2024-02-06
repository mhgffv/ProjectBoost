using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWork : MonoBehaviour
{
    public GameObject Coin;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Friendly")
        {
            Coin.SetActive(false);
        }
    }
}

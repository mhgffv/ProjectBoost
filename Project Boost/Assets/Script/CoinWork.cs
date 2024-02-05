using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWork : MonoBehaviour
{
    public GameObject Coin;
    void OnTriggerEnter(Collider other)
    {
        Coin.SetActive(false);
    }
}

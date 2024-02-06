using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemywork : MonoBehaviour
{
    public GameObject Enemy;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Friendly")
        {
            Enemy.SetActive(false);
        }
    }
}

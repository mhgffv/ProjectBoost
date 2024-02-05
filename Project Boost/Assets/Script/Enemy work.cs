using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemywork : MonoBehaviour
{
    public GameObject Enemy;
    void OnTriggerEnter(Collider other)
    {
        Enemy.SetActive(false);
    }
}

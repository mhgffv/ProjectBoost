using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelWork : MonoBehaviour
{
    public GameObject Fuel;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Friendly")
        {
            Fuel.SetActive(false);
        }
    }
}

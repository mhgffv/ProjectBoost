using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] float ThrustPower;

    public AudioClip EngineSound;
    public GameObject Particulas;

    AudioSource aSource;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
        Particulas.SetActive(false);
    }
    void Update()
    {
        ThrustProces();
        RotateProces();
    }
    void ThrustProces()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //Fuel Consume
            //Fuel Necesity
            //out of fuel Sound
            rb.AddRelativeForce(Vector3.up * ThrustPower * Time.deltaTime);
            if(!aSource.isPlaying)
            {
                aSource.PlayOneShot(EngineSound);
            }
            Particulas.SetActive(true);

        }

        else
        {
            Particulas.SetActive(false);
            aSource.Stop();
        }
    }

    void RotateProces()
    {
        if(Input.GetKey("a"))
        {
            Rotation(RotationSpeed);
        }
        else if(Input.GetKey("d"))    
        {
            Rotation(-RotationSpeed);
        }
    }

    void Rotation(float RotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}

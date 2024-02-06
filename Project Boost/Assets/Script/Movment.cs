using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] float ThrustPower;

    public AudioClip EngineSound;
    public GameObject ParticulasMotor;
    public GameObject ParticulasDerecha;
    public GameObject ParticulasIzquierda;

    AudioSource aSource;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
        ParticulasMotor.SetActive(false);
        ParticulasDerecha.SetActive(false);
        ParticulasIzquierda.SetActive(false);
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
            ParticulasMotor.SetActive(true);

        }
        else
        {
            ParticulasMotor.SetActive(false);
            aSource.Stop();
        }
    }

    void RotateProces()
    {
        if(Input.GetKey("a"))
        {
            Rotation(RotationSpeed);
            ParticulasIzquierda.SetActive(true);
        }
        else if(Input.GetKey("d"))    
        {
            Rotation(-RotationSpeed);
            ParticulasDerecha.SetActive(true);
        }
    }

    void Rotation(float RotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}

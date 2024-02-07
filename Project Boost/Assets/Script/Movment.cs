using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] float ThrustPower;

    public AudioClip EngineSound;

    public ParticleSystem ParticulasMotor;
    public ParticleSystem ParticulasDerecha;
    public ParticleSystem ParticulasIzquierda;

    AudioSource aSource;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
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

            if(!ParticulasMotor.isPlaying)
            {
                ParticulasMotor.Play();
            }

        }
        else
        {
            aSource.Stop();
            ParticulasMotor.Stop();
        }
    }

    void RotateProces()
    {
        if(Input.GetKey("a"))
        {
            Rotation(RotationSpeed);
            if (!ParticulasDerecha.isPlaying)
            {
                ParticulasDerecha.Play();
            }
        }

        else if(Input.GetKey("d"))    
        {
            Rotation(-RotationSpeed);
            if (!ParticulasIzquierda.isPlaying)
            {
                ParticulasIzquierda.Play();
            }
        }
        else
        {
            ParticulasIzquierda.Stop();
            ParticulasDerecha.Stop();
        }
    }

    void Rotation(float RotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}

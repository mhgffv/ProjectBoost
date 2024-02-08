using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colision : MonoBehaviour
{
    [SerializeField] float Retardtime = 2f;
    float HP = 100f;
    float Coins = 0f;

    bool IsTransition = false;
    bool Cheat = false;

    public AudioClip CoinSound;
    public AudioClip FuelSound;
    public AudioClip CrashSound;
    public AudioClip LoseSound;
    public AudioClip WinSound;

    public ParticleSystem LoseParticles;
    public ParticleSystem WinnParticles;

    AudioSource audioSource;
    Rigidbody rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        CheatMode();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!IsTransition || !Cheat)
        {
                switch(other.gameObject.tag)
                {
                    case "Start":

                    break;

                    case "Fuel":
                        Iffuel();
                    break;

                    case "Enemy":
                        Ifenemy();
                    break;

                    case "Coin":
                        Ifcoin();
                    break;

                    case "End":
                        Ifend();
                    break;

                    case "Wall":
                        General();
                    break;
                }     
            
        }  
    }
    void OnCollisionEnter(Collision other)
    {
        if(!Cheat)
        {
            if(!IsTransition)
            {
                if(other.gameObject.tag == "Wall")
                {
                    General();
                }
            }
        }
    }

    void Iffuel()
    {
        audioSource.PlayOneShot(FuelSound);
    }

    void Ifenemy()
    {
       audioSource.PlayOneShot(CrashSound);
       HP = HP - 25f;
       Debug.Log(HP + "% de vida");
       CrashSecuence();
    }

    void Ifcoin()
    {   
        audioSource.PlayOneShot(CoinSound);
        Coins++;
        Debug.Log(Coins + " Monedas");
    }

    void Ifend()
    {
        Debug.Log("gg");
        SuccesSecuence();
    }

    void General()
    {
        audioSource.PlayOneShot(CrashSound);
        Debug.Log("SiPared");
        HP = HP - 50f;
        CrashSecuence();
    }
    

    void CrashSecuence()
    {
        if(HP < 1)
        {
            LoseParticles.Play();
            IsTransition = true;
            audioSource.Stop();
            audioSource.PlayOneShot(LoseSound);
            rb.freezeRotation = true;
            //rb.freezePosition;
            GetComponent<Movment>().enabled = false;
            Invoke("ResetLevel", Retardtime);
        }
    }
    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SuccesSecuence()
    {
        IsTransition = true;
        audioSource.Stop();
        audioSource.PlayOneShot(WinSound);
        WinnParticles.Play();
        rb.freezeRotation = true;
        //rb.FreezePosition = true;
        GetComponent<Movment>().enabled = false;
        Invoke("NextLevel", Retardtime);

        
    }
    void NextLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        int LevelChanger = CurrentScene + 1;
        if (LevelChanger == SceneManager.sceneCountInBuildSettings)
        {
            LevelChanger = 0;
        }
        SceneManager.LoadScene(LevelChanger);
    }

    void CheatMode()
    {
        if(Input.GetKey("c"))
        {
            Cheat = !Cheat;
            if(Cheat == false)
            {
                Debug.Log("Cheat Desactivado");
            }
            if(Cheat == true)
            {
                Debug.Log("Cheat activado");
            }
        }

        if(Input.GetKey("l"))
        {
            NextLevel();
        }
    }
}
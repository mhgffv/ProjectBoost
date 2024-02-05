using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colision : MonoBehaviour
{
    [SerializeField] float Retardtime = 2f;
    float HP = 100f;
    float GasAmaunt = 10f;
    float Coins = 0f;

    public GameObject Gas;
    public GameObject Coin;

    public AudioClip CoinSound;
    public AudioClip FuelSound;
    public AudioClip CrashSound;
    public AudioClip LoseSound;
    public AudioClip WinSound;

    AudioSource audioSource;
    Rigidbody rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
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

    void Iffuel()
    {
        audioSource.PlayOneShot(FuelSound);
        GasAmaunt = GasAmaunt + 3;
        Debug.Log(GasAmaunt + " gas");
        Gas.SetActive(false);
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
        Debug.Log("SiPared");
        HP = HP - 100f;
        CrashSecuence();
    }
    

    void CrashSecuence()
    {
        if(HP < 1)
        {
            audioSource.PlayOneShot(LoseSound);
            //Crash Particles
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
        audioSource.PlayOneShot(WinSound);
        //Wining Particles
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
}
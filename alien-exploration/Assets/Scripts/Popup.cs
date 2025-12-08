//using System;
//using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour
{

    public GameObject popUp;

    //private AudioSource audioSourcePrivate;
    private AudioSource audioSource;

   //[SerializeField] private AudioClip phoneRingClip;
    public AudioClip[] statements = new AudioClip[3];

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        popUp.SetActive(false);

        InvokeRepeating("AudioArray", 2f, 60f);

        
    }

    // Update is called once per frame
    void Update()
    {
       // popUp.SetActive(false);
    }

    public void AudioArray()
    {
        int randomStatmentIndex = Random.Range(0, statements.Length);
        audioSource.clip = statements[randomStatmentIndex];
        audioSource.Play();

       // PlayBuzz();

        StartCoroutine(ShowPopUp());
    }

    //public void PlayBuzz()
    //{
    //    audioSource.clip = phoneRingClip;
    //    audioSource.Play();
        
    //}

    public void PopUpON()
    {
        Debug.Log("popup on");
        popUp.SetActive(true);
        
    }
    IEnumerator ShowPopUp()
    {
        
        popUp.SetActive(true);
        Debug.Log("popup on");
        yield return new WaitForSeconds(1.5f);
        popUp.SetActive(false);
        
    }
}

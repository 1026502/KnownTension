using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioPlayer : MonoBehaviour
{

    public AudioSource[] audios;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayofSound()); 
    }

  
    IEnumerator DelayofSound()
    {
        int i = Random.Range(30, 120);
        yield return new WaitForSeconds(i);
        int soundfile = Random.Range(0, audios.Length);
        audios[soundfile].Play();

        StartCoroutine(DelayofSound());


    }

}

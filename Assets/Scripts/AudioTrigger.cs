using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    public AudioSource audioHolder;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SoundDelay());
        }
    }

    IEnumerator SoundDelay()
    {
        int i = Random.Range(1, 5);
        yield return new WaitForSeconds(i);
        audioHolder.Play();

    }
}

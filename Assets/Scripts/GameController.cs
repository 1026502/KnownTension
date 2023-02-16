using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Transform[] interactableSpawnPoints;
    public GameObject keyModel;
    public GameObject[] lightSources;
    public AudioSource[] lightSounds;
    public GameObject[] textPrompts;

    public bool playerHasKey;
    // Start is called before the first frame update
    void Start()
    {
        playerHasKey = false;
        textPrompts[0].gameObject.SetActive(true);

        StartCoroutine(GameOpening());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        SpawnKey();

        for(int i = 0; i < lightSources.Length; i++)
        {
            StartCoroutine(FlickerLight(lightSources[i]));
        }
        
    }

    void SpawnKey()
    {
        int i = Random.Range(0, 13);

        Instantiate(keyModel, interactableSpawnPoints[i].position, Quaternion.identity);

        Debug.Log("Key has spawned at spawn point " + i);
        



    }

    IEnumerator FlickerLight(GameObject light)
    {
        int i = Random.Range(2, 10);

        yield return new WaitForSeconds(i);

        


        if (light.activeSelf == true)
        {
            light.SetActive(false);
            lightSounds[1].Play();
            

        }
        else
        {
            light.SetActive(true);
            lightSounds[0].Play();
            

        }

        StartCoroutine(FlickerLight(light));
        
    }


    IEnumerator GameOpening()
    {
        int time = 5;

        yield return new WaitForSeconds(time);

        textPrompts[0].gameObject.SetActive(false);
        

        yield return new WaitForSeconds(2);

        textPrompts[1].gameObject.SetActive(true);

        yield return new WaitForSeconds(time);

        textPrompts[1].gameObject.SetActive(false);
    }


    public IEnumerator TextTrigger()
    {
        textPrompts[2].SetActive(true);
        textPrompts[3].SetActive(true);

        yield return new WaitForSeconds(3);

        textPrompts[2].SetActive(false);
    }
}

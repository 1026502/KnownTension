using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Transform[] interactableSpawnPoints;
    public GameObject keyModel;
    public GameObject[] lightSources;

    public bool playerHasKey;
    // Start is called before the first frame update
    void Start()
    {
        playerHasKey = false;
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
        int i = Random.Range(1, 6);

        yield return new WaitForSeconds(i);


        if (light.activeSelf == true)
        {
            light.SetActive(false);

        }
        else
        {
            light.SetActive(true);
        }

        StartCoroutine(FlickerLight(light));
        
    }
}

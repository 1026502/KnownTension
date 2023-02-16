using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameController controller;
    public GameObject[] winTriggerObjects;
    // Start is called before the first frame update
    void Start()
    {
       controller = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && controller.playerHasKey == true)
        {
            //Enable win screen
            winTriggerObjects[0].SetActive(true);

        }
        else
        {
            //Enable UI prompt
            StartCoroutine(promptDelay());

        }
    }


    IEnumerator promptDelay()
    {
        winTriggerObjects[1].SetActive(true);

        yield return new WaitForSeconds(4);

        winTriggerObjects[1].SetActive(false);
    }
}

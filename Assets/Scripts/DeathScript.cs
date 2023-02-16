using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameController controller;
    public GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
     controller = FindObjectOfType<GameController>();
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //jscare / Death screen.
            endScreen.SetActive(true);
            

        }
    }
}

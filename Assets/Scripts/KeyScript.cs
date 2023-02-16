using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

  

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter has been called from" + other.name);

        if (other.gameObject.tag == "Player")
        {
            controller.playerHasKey = true;
            Debug.Log("key has been picked up!");
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}

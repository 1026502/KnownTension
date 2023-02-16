using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;
    public float jumpHeight = 1f;
    public Light playerLight;
    public AudioSource lightSound;
    Vector3 velocity;
    bool isGrounded;
    bool lightStatus;

    // Start is called before the first frame update
    void Start()
    {
        lightStatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

       velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Interact"))
        {
            lightSound.Play();

            if (lightStatus == true)
            {
                
                playerLight.enabled = false;
                lightStatus = false;
            }
            else
            {
                
                playerLight.enabled = true;
                lightStatus = true;

            }
        }

        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    #region Core Game Stats Area (typed by AG)
    public float mouseSens = 1000f;
    public Transform playerBody;
    float xRotation = 0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        mouseSens = 1000f;
#endif
#if UNITY_WEBGL
        mouseSens = 50f;
#endif
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}

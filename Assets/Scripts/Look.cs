using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform player;

    public float mouseSens;

    float x = 0;
    float y = 0;

    public bool lockRot;

    float lookBehind;
    public float flipValue;

    public bool lookingBehind, enableLookBack, flipMode;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        mouseSens = PlayerPrefs.GetFloat("Sensitivity", 100);
    }

    // Update is called once per frame
    void Update()
    {
        if(enableLookBack)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                lookBehind = 180;
            }
            else
            {
                lookBehind = 0;
            }
        }
        if (!lockRot)
        {
            x += -Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
            y += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        }
        lookingBehind = lookBehind == 180;
        flipMode = flipValue == 180;
        //Clamp camera

        y = y % 360;
        x = Mathf.Clamp(x, -90, 90);

        //Rotate camera to axis
        transform.localRotation = Quaternion.Euler(x, lookBehind, flipValue);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}

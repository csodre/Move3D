using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform corpo;
    public Transform cabeca;

    float rotationX = 0;
    float rotationY = 0;
    float angleYmin = -45.0f;
    float angleYmax = 45.0f;
    float mouseSens = 2.5f;
    float suavidadeCam = 0.1f;

    float suavidadeRotX=0;
    float suavidadeRotY=0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.position = cabeca.position;
    }

    void Update()
    {
        float moveVertival = Input.GetAxis("Mouse Y")*mouseSens;
        float moveHorizontal = Input.GetAxis("Mouse X")*mouseSens;

        suavidadeRotX = Mathf.Lerp(suavidadeRotX,moveHorizontal,suavidadeCam);
        suavidadeRotY = Mathf.Lerp(suavidadeRotY,moveVertival,suavidadeCam);



        rotationX += suavidadeRotX;
        rotationY += suavidadeRotY;

        rotationY = Mathf.Clamp(rotationY,angleYmin,angleYmax);

        corpo.localEulerAngles = new Vector3(0,rotationX,0);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }
}

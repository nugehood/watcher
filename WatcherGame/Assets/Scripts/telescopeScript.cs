using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class telescopeScript : MonoBehaviour
{
    public Camera telescopeCam;

    public GameObject telescopeImg;

    float RotationSpeed;
    float xRot, yRot;

    void Start()
    {
        RotationSpeed = 100;
        yRot = -90f;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        //Rotation value
        xRot += mouseY;
        yRot += mouseX;
        //Rotation Limit
        xRot = Mathf.Clamp(xRot, -20f, 20f);
        yRot = Mathf.Clamp(yRot, -180f, -23f);


        //Object Local rotation
        transform.localRotation = Quaternion.Euler(xRot, yRot, 90f);

        //Telescope zoom Min and Max
        telescopeCam.fieldOfView = Mathf.Clamp(telescopeCam.fieldOfView, 50,80);
        
        if (Input.mouseScrollDelta.y < 0f)
        {
            telescopeCam.fieldOfView += 2;
        }
        else if (Input.mouseScrollDelta.y > 0f)
        {
            telescopeCam.fieldOfView -= 2;
        }



    }
}

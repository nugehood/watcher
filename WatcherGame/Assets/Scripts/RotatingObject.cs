using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

//Put script only on the rotation pivot!

public class RotatingObject : MonoBehaviour
{
    public float RotationSpeed;
    float xRot;
    float yRot;
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        //Rotation value
        xRot -= mouseY;
        yRot -= mouseX;
        //Rotation Limit
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        

        transform.localRotation = Quaternion.Euler(xRot, yRot, 90f);

    }

 
}

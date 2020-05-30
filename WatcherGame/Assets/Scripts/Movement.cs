using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    CharacterController characterController;
    [Tooltip("Change the speed of player movement")]
    public float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Axis Inputs value
        float x = Input.GetAxis("Horizontal");
        //Vectical Axis Inputs value
        float z = Input.GetAxis("Vertical");
        //Movement mechanic by multiplying right and forward transform by the given Input value
        Vector3 Mov = transform.right * x + transform.forward * z;

        //Moving character
        characterController.SimpleMove(Mov * MovementSpeed);
    }
}

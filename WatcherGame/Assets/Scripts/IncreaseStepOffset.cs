using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Triggers/IncreaseStepOffset")]
[RequireComponent(typeof(BoxCollider))]
public class IncreaseStepOffset : MonoBehaviour
{
    
    [Header("Change stepOffset on Trigger!")]
    CharacterController characterController;
    [Tooltip("Offset when player enter the trigger")]
    public float onEnterstepOffset;
    [Tooltip("Offset when player exit the trigger")]
    public float onExitstepOffset;

    public void OnTriggerEnter(Collider other)
    {
        
        //If player entered the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            //Getting component of type CharacterController with collider data
            characterController = other.gameObject.GetComponent<CharacterController>();
            //Setting characterController offset to the given value when entering Trigger
            characterController.stepOffset = onEnterstepOffset;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        //Setting characterController offset to the given value when exiting Trigger
        characterController.stepOffset = onExitstepOffset;
        
    }
}

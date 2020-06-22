using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class lightSwitchScript : MonoBehaviour
{
    Animator animator;
    public Light lighting;
    public AudioClip switchOn,switchOff;
    [HideInInspector]
    public bool isOn;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            isOn = false;
        }*/
        animator.SetBool("light", isOn);
        if (isOn)
        {
            lighting.enabled = true;
        }

        else
        {
            lighting.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoneScript : MonoBehaviour
{

    [HideInInspector]
    public bool ableToUsePhone;

    public GameObject MainScreen, AppScreen;

    public MouseLook cameraMovement;

    public Movement playerMovement;

    public pauseScript pauseScript;

    Animator animator;
    bool outPar;
    int appOrder;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        appOrder = -1;
        ableToUsePhone = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Phone animation coming on screen State
        animator.SetBool("in", outPar);
        
        //App animation state
        animator.SetInteger("app", appOrder);

        if (ableToUsePhone)
        {
            //Open phone when it is not out
            //Using middle mouse button
            //Disable movement, camera movement and pause
            if (Input.GetMouseButtonDown(2) && !outPar)
            {
                cameraMovement.enabled = false;
                playerMovement.enabled = false;

                pauseScript.abletoPause = false;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                outPar = true;
                appOrder = -1;
            }

            //Close phone when it is out
            //Using middle mouse button
            //Enable     movement, camera movement and pause
            else if (Input.GetMouseButtonDown(2) && outPar)
            {
                cameraMovement.enabled = true;
                playerMovement.enabled = true;

                pauseScript.abletoPause = true;

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                outPar = false;
                appOrder = 0;
            }

            //If no apps then close
            if (appOrder == 0)
            {
                MainScreen.SetActive(true);
                AppScreen.SetActive(false);

            }

        }


    }

    //App value assign to different app with different state
    public void appValue(int appVal)
    {
        appOrder = appVal;
    }

    



}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    

    Movement playerMovement;
    [Tooltip("Adjust mouse Sensitivity")]
    [Range(60,100)]
    public float MouseSensitivity;
    [Space]
    [Tooltip("Put player transform component here!")]
    public Transform playerBody;
    float xRot = 0f;
    RotatingObject rotationObj;

    public bool invertMouse;

    lightSwitchScript lightSwitch;

    bool camRotation;
    bool isUseTelescope;
    
    RayCastObjectName castobjName;
   
    GameObject getCastObj;

    telescopeScript teleScript;

    public pauseScript pausescript;

    // Start is called before the first frame update
    void Start()
    {
        
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        camRotation = true;
        //Invisible cursor and locking state
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {


        //If camera rotation is Enable
        if (camRotation)
        {
            //Get mouse position multiply by MouseSensitivity
            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            //Rotate playerbody left/right multiply by the result of mouseX/Horizontal value
            playerBody.Rotate(Vector3.up * mouseX);

            //Rotation value
            if (!invertMouse)
            {
                xRot -= mouseY;
            }

            else if (invertMouse)
            {
                xRot += mouseY;
            }
            //Clamping the rotation value or the value of xRot to only be able to exceed only the given minimum 
            //and maximum value
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            //Rotate camera not inherting rotation from the parents object
            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
        //If camera doesn't rotate then rotation value return to 0
        else
        {
            xRot = 0;
        }
        //Raycast in the middle of viewport
        Ray ray;
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,5))
        {
            //If raycast hit rotateable then you can rotate object
            //Disabling movement and Camera rotation
            if (hit.collider.CompareTag("rotateable"))
            {
                rotationObj = hit.collider.GetComponent<RotatingObject>();
                if (Input.GetMouseButtonDown(0)) { 
                playerMovement.enabled = false;
                camRotation = false;
                rotationObj.enabled = true;
                }
                //If hit telescope
                if (Input.GetMouseButtonDown(0) && hit.collider.GetComponent<telescopeScript>())
                {
                    pausescript.abletoPause = false;
                    teleScript = hit.collider.GetComponent<telescopeScript>();
                    teleScript.enabled = true;
                    teleScript.telescopeCam.enabled = true;
                    teleScript.telescopeImg.SetActive(true);
                }

            }
            
            //Lightswitch turning on and of
            
            if (hit.collider.CompareTag("lightswitch"))
            {
                
                lightSwitch = hit.collider.GetComponent<lightSwitchScript>();

                //If light is on
                if (Input.GetMouseButtonDown(0)&&lightSwitch.isOn){

                    lightSwitch.isOn = false;

                }

                //If light is off
                else if (Input.GetMouseButtonDown(0) &&!lightSwitch.isOn)
                {

                    lightSwitch.isOn = true;

                }

            }
            //Checking if it has RayCastObjectName
            if(hit.collider.GetComponents<RayCastObjectName>() != null)
            {
                castobjName = hit.collider.GetComponent<RayCastObjectName>();

            }
            //If castobjName is available
            //Then active the objectText, assign it to getCastObj
            if (castobjName != null)
            {
                castobjName.objectText.SetActive(true);
                getCastObj = castobjName.objectText;
            }
            //If castobjName is not available
            else if (castobjName == null)
            {
                //getCastObj disable
                getCastObj.SetActive(false);
            }


        }
        //If you can rotateObject then disbale Raycastobject text GameObject
        if (rotationObj.enabled)
        {
          getCastObj.SetActive(false);
          castobjName.isCast = false;

        }

        //If object rotation is enable then pressing right mouseButton disable it
        //Allowing movement and camera movement
        if (rotationObj.enabled&&Input.GetMouseButtonDown(1))
        {
            pausescript.abletoPause = true;
            playerMovement.enabled = true;
            camRotation = true;
            rotationObj.enabled = false;
            rotationObj = null;
        }

        if(teleScript.enabled == true&& Input.GetKeyDown(KeyCode.E) | Input.GetMouseButtonDown(1))
        {
            Camera.main.enabled = true;
            teleScript.enabled = false;
            teleScript.telescopeCam.enabled = false;
            teleScript.telescopeImg.SetActive(false);
        }

       

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    Movement playerMovement;
    [Tooltip("Adjust mouse Sensitivity")]
    public float MouseSensitivity;
    [Space]
    [Tooltip("Put player transform component here!")]
    public Transform playerBody;
    float xRot = 0f;
    RotatingObject rotationObj;
    bool camRotation;
    [HideInInspector]
    public RayCastObjectName castobjName;
    [HideInInspector]
    public GameObject getCastObj;

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
            xRot -= mouseY;
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

            if (Input.GetMouseButtonDown(0))
            {
                //If raycast hit rotateable then you can rotate object
                //Disabling movement and Camera rotation
                
                if (hit.collider.CompareTag("rotateable"))
                {
                    playerMovement.enabled = false;
                    camRotation = false;
                    rotationObj = hit.collider.GetComponent<RotatingObject>();
                    rotationObj.enabled = true;
                    
                }
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
            playerMovement.enabled = true;
            camRotation = true;
            rotationObj.enabled = false;
            rotationObj = null;
        }

    }
}

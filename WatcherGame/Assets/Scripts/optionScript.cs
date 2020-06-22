using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class optionScript : MonoBehaviour
{
    [Tooltip("Disable cursor or not? Apply this mainly for main Menu")]
    public bool disableCursor;

    [Header("Mouse Option")]
    //Mouse Variable
    [Tooltip("Put your MouseLook variable here for chaning camera movement, etc")]
    public MouseLook cameraScript;

    [Tooltip("Slider for mouseSensitivity on MouseOptions")]
    public Slider mouseSensitivitySlider;

    [Tooltip("Toggle from MouseOptions")]
    public Toggle mouseinvertToggle;


    [HideInInspector]
    public bool mouseInvert;

    
    //Display Variable 
    int screenWidth, screenHeight;

    int screenResIndex;
    [HideInInspector]
    public string screenRes;

    [Header("Display Option")]
    [Tooltip("Put your fullscreenToggle from display option here!")]
    public Toggle fullscreenToggle;
    [Tooltip("Put the resolution text here!")]
    public Text resolutionText;

    [Space]
    [Tooltip("Pause script component from Player")]
    public pauseScript pausescript;

    [Header("Audio Option")]
    //Audio options variable
    [Tooltip("Mixer can be found on asset, assign it here!")]
    public AudioMixer mixer;
    
    [Tooltip("Slider from audio option!")]
    public Slider ambientSlider, fxSlider;

    [Space]
    public phoneScript phonescript;

    
    
    // Start is called before the first frame update
    void Start()
    {
        //Default resolution on Start Game
        fullscreenToggle.isOn = true;
        screenHeight = Screen.currentResolution.height;
        screenWidth = Screen.currentResolution.width;
        Screen.SetResolution(screenWidth, screenHeight, fullscreenToggle.isOn);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Limit of screenIndex
        screenResIndex = Mathf.Clamp(screenResIndex, 0, 2);

        //Set resolution text to screenRes base on the switch case from Index!
        resolutionText.text = screenRes.ToString();


        //Switch case for screen resolution data and cycling resolution
        switch (screenResIndex)
        {
            case 0:
                screenWidth = 1280;
                screenHeight = 720;
                screenRes = "1280x720";
                break;
            case 1:
                screenWidth = 1366;
                screenHeight = 728;
                screenRes = "1366x728";
                break;

            case 2:
                screenWidth = 1920;
                screenHeight = 1080;
                screenRes = "1920x1080";
                break;
        }


    }

    //Assign this method to nextRes button onClick()
    public void nextResolutionIndex()
    {
        screenResIndex += 1;
    }

    //Assign this method to preRes button onClick()
    public void previousResolutionIndex()
    {
        screenResIndex -= 1;
    }

   

    //ApplySetting assign this method on Applybutton onClick()
    public void applySettings()
    {
        //Setting the resoltuion and fullscreen
        Screen.SetResolution(screenWidth, screenHeight, fullscreenToggle.isOn);
        
        //Assign player MouseLook invertMouse value equal to mouseInvertoogle
        //If isOn/check then invert if not then otherwise

        cameraScript.invertMouse = mouseinvertToggle.isOn;

        //Player MouseLook sensitivity get value from the Slider
        cameraScript.MouseSensitivity = mouseSensitivitySlider.value;

        //Close the optionMenu
        this.gameObject.SetActive(false);

        //Allow camera movement
        cameraScript.enabled = true;

        if (disableCursor)
        {
        //Don't show cursor
        Cursor.visible = false;

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        }

        //Unmute audio
        mixer.SetFloat("masterVol", 0);


        pausescript.isPaused = false;

        //Able to use phone
        phonescript.ableToUsePhone = true;

        //Revert back to normal time
        Time.timeScale = 1f;
    }

    //Default setting method put in Default button onClick()
    public void defaultSetting()
    {
        ambientSlider.value = 0.43f;
        fxSlider.value = 0.22f;

        screenResIndex = 0;
        fullscreenToggle.isOn = true;
        mouseinvertToggle.isOn = false;
        mouseSensitivitySlider.value = 80;



    }

    public void quitMenu()
    {
        mixer.SetFloat("masterVol", 0);
        SceneManager.LoadScene("MainMenu");
    }

    

     
}

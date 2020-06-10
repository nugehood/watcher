using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class pauseScript : MonoBehaviour
{
    [Tooltip("Put the MainCamera on player here!")]
    public MouseLook Look;
    [HideInInspector]
    public bool isPaused;

    [HideInInspector]
    public bool abletoPause;

    [Tooltip("Put the pausePanel Here!")]
    public GameObject pausePanel;

    public phoneScript phone;

    public AudioMixer mixer;

    private void Start()
    {
        abletoPause = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if (abletoPause)
        {
            //Pausing the game
            if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            {

                //Show cursor and move freely
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                //Disable camera movement
                Look.enabled = false;

                //Enable pause menu
                pausePanel.SetActive(true);
                isPaused = true;

                //Mute audio
                mixer.SetFloat("masterVol", -80);

                //Can't use phone
                phone.ableToUsePhone = false;

                //Freezing the timescale/Stopping time
                Time.timeScale = 0;
            }
            //Unpause game
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            {
                //Don't show cursor and lock it
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                //Enable camera movement
                Look.enabled = true;

                //Disable pause menu
                pausePanel.SetActive(false);
                isPaused = false;

                //Unmute Audio
                mixer.SetFloat("masterVol", 0);

                //Able to use phone
                phone.ableToUsePhone = true;

                //Normal timescale
                Time.timeScale = 1;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    [Tooltip("Put the MainCamera on player here!")]
    public MouseLook Look;
    bool isPaused;
    [Tooltip("Put the pausePanel Here!")]
    public GameObject pausePanel;

    // Update is called once per frame
    void Update()
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

            //Freezing the timescale/Stopping time
            Time.timeScale = 0;
        }
        //Unpause game
        else if(Input.GetKeyDown(KeyCode.Escape)&& isPaused)
        {
            //Don't show cursor and lock it
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            //Enable camera movement
            Look.enabled = true;

            //Disable pause menu
            pausePanel.SetActive(false);
            isPaused = false;

            //Normal timescale
            Time.timeScale = 1;
        }
    }
}

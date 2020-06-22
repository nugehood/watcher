using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [Header("Scene")]
    public string SceneName;
    public float Delay;
    [Space]
    [Tooltip("Put your animator for fading here!")]
    public Animator fadeAnimator;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    //Starting coroutine for loading a scene
    public void buttonLoadScene()
    {
        StartCoroutine(loadScene(Delay, SceneName));
    }

    //Fading scene and then wait for delay to move to the next scene
    public IEnumerator loadScene(float delay,string scenename)
    {
        fadeAnimator.SetTrigger("out");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scenename);


    }

    //Quit games/software
    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public float Delay;

    public void sceneLoad()
    {
        StartCoroutine(loadScene(Delay, sceneName));
    }

    public IEnumerator loadScene(float delay,string scenename)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
    
}

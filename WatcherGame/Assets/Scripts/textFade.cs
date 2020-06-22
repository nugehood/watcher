using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textFade : MonoBehaviour
{
    public Text[] text;
    public float Delay;
    float a=1;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(Fade(Delay));
    }
  
    IEnumerator Fade(float delay)
    {
        yield return  new WaitForSeconds(delay);
       
        for(int i=0;i <= text.Length; i++)
        {

        for (float ft = 1f; ft >= -1; ft -= 0.1f)
        {
            Color t = text[i].color;
            t.a = ft;
            text[i].color = t;
            yield return null;
        }

        }
    }
}

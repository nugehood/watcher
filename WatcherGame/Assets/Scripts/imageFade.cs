using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageFade : MonoBehaviour
{
    public Image[] images;

    public float Delay;

    private void OnEnable()
    {
        
        StartCoroutine(fade(Delay));
    }
   

    public IEnumerator fade(float delay)
    {
        yield return new WaitForSeconds(delay);
        for(int i = 0;i <= images.Length; i++)
        {
            for(float ft = 1f;ft >= -1;ft -= 0.1f)
            {
                Color img = images[i].color;
                img.a = ft;
                images[i].color = img;
                yield return null;
            }
        }
    }
}

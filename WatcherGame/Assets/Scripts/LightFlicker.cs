using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light light;
    public float intensity;
    public float seconds;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = intensity;
        StartCoroutine(flicker(seconds));
    }

    public IEnumerator flicker(float second)
    {
        intensity = 1.003022e+07f;
        yield return new WaitForSeconds(second);
        intensity = 1.003022e+06f;
        
    }
}

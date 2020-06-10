using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastObjectName : MonoBehaviour
{
    
    public GameObject objectText;
    [HideInInspector]
    public bool isCast;

    // Update is called once per frame
    void Update()
    {
        
        if (isCast)
        {
            objectText.SetActive(true);
        }
        else
        {
            objectText.SetActive(false);
        }
        
    }
}

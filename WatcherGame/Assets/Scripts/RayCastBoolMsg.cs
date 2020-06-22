using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBoolMsg : MonoBehaviour
{
    [Tooltip("Message that you wish to change the bool")]
    public messageContactScript msg;
    [HideInInspector]
    public bool cast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Make the next message available when click
        if (cast)
        {
            msg.isClick[msg.a] = true;
            cast = false;
        }
        
    }
}

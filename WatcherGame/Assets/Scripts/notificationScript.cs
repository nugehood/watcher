using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notificationScript : MonoBehaviour
{

    public messageContactScript msg;
    public GameObject notifImg;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!msg.read)
        {
            notifImg.SetActive(true);
            
        }
        else
        {
            notifImg.SetActive(false);
        }
    }
}

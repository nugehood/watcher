using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeName : MonoBehaviour
{
    GameObject prev;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        prev = GameObject.Find("Bubble" + index);
        gameObject.name = "Bubble" + index;
    }

    // Update is called once per frame
    void Update()
    {
        
            gameObject.name = "Bubble" + index;
    }
}

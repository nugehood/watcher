using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class messageData : MonoBehaviour
{
    Text teks;
    messageContactScript ms;
    // Start is called before the first frame update
    void Start()
    {
        //Get parent name
        ms = GameObject.Find(transform.parent.parent.parent.parent.parent.parent.name).GetComponent<messageContactScript>();
        teks = GetComponent<Text>();
        //Message bubble text from messageContractScript string
        teks.text = ms.msg[ms.a].ToString();
    }

}

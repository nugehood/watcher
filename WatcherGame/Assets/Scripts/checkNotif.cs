using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class checkNotif : MonoBehaviour
{
    public messageContactScript[] messageContact;

    public Button btn;

    bool allRead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(bool r in messageContact)
        {
            if (r)
            {
                
                allRead = true;
            }
            else
            {
               
                allRead = false;
                break;
            }
        }
        for(int i=0;i <= messageContact.Length; i++)
        {
            //Masih ada pesan yg belum terbaca
            if (!messageContact[i].read)
            {
                btn.interactable = true;
            }
            //Semua pesan telah dibaca/salah satu?
            else if (allRead)
            {
                btn.interactable = false;
            }
        }
    }
}

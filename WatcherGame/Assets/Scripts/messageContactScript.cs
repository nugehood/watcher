using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class messageContactScript : MonoBehaviour
{
    Vector3 parentPosition;

    [TextArea(5,2)]
    public string[] msg;

    [HideInInspector]
    public bool read;

    public bool[] isClick;

    [Tooltip("Put bubble message Prefabs")]
    public GameObject contactBubble;

    public Button sendBtn;

    public Transform content,newObj;

    public bool[] occupy;

    [HideInInspector]
    public int a,offset,notifindex;

    private void Start()
    {
       
    }
    private void Update()
    {
    
        //Assigning vector3 for getting parent Obj transform
        parentPosition = content.transform.position;
        if(isClick[a] == true)
        {
            sendBtn.image.color = Color.white;
            sendBtn.enabled =   true;
            read = false;
        }

        else
        {
            sendBtn.image.color = Color.red;
            sendBtn.enabled = false;
            read = true;
        }
      

        //Disable Button if message End
        if(a == msg.Length-1)
        {
            read = true;
            sendBtn.image.color = Color.red;    
            sendBtn.enabled = false;
            Debug.Log("BRUH");
        }
        
    }

    //Make new messages appear
    public void nextMessage(int length)
    {
      
       
       a += 1;
       //Create new bool inside the arrray perClick
       occupy = new bool[a];
        
       //Spawn object next position;
       newObj.transform.position = new Vector2(984.1915f, 483.5491f - offset);

       //Offset for the next message
       offset += 130;

       //Create new Message bubble object
       Instantiate(contactBubble, newObj.transform.position, Quaternion.identity, content);


        //Make the newly created array to true
        for(int i = 0;i <= length; i++)
        {

            if(occupy[i] == false)
            {
               occupy[i] = true;
            }

        }
        

        
        


    }
}

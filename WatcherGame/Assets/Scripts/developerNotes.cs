using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USED ONLY BY THE PROGRAMMER!  
[AddComponentMenu("DeveloperTools/DevNote")]
public class developerNotes : MonoBehaviour
{
    [Header("Please READ!")]
    [TextArea(5,2)]
    public string note;
    [Header("What do you need?")]
    public bool Another_Script;
    public string[] scriptName;

    [Space]
    public bool Another_Component;
    public string[] componentName;
   
    [Space]
    public bool Another_GameObject;
    public string[] GameObjectName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

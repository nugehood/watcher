using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{

    public Transform TargetObject;
  

    public void LateUpdate()
    {
        
        transform.LookAt(TargetObject);
       
    }
}

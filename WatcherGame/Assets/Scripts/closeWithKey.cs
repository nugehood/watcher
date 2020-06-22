using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeWithKey : MonoBehaviour
{
    [Header("Disble Object With Key!")]
    public KeyCode keys;
    public GameObject Obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys))
        {
            Obj.SetActive(false);
        }
    }
}

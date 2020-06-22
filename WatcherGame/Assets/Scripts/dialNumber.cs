using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialNumber : MonoBehaviour
{
    public Image contactImage;

    public Text contactNametxt;

    public InputField dialField;

    public Contact[] contactList;

    public Animator callingWindow;

    public phoneScript Phonescript;

    public closeWithKey closeThisapp;

    //Input a number into the InputField   
    public void numberDial(int number)
    {
        dialField.text += number;
    }

    //Call number
    public void call()
    {
        //Cycle every data
        foreach(Contact num in contactList)
        {
            //If same number
            if(dialField.text == num.Number.ToString())
            {
                contactNametxt.text = num.contactName.ToString();
                contactImage.sprite= num.contactImg;
                callingWindow.SetBool("call", true);
                Phonescript.ableToUsePhone = false;
                closeThisapp.enabled = false;
            }
            
        }
    }

    public void Hangup()
    {
        callingWindow.SetBool("call", false);
        Phonescript.ableToUsePhone = true;
        closeThisapp.enabled = true;
    }

    public void clearText()
    {
        dialField.text = "";
    }
}

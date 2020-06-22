using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Contact
{
    public int Number;
    public string contactName;
    public Sprite contactImg;

    public Contact(int Number, string contactName, Sprite contactImg)
    {
        this.Number = Number;
        this.contactName = contactName;
        this.contactImg = contactImg;
    }
}

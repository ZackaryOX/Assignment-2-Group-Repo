using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickUp : Interactable
{
    public static Dictionary<string, PickUp> AllItems = new Dictionary<string, PickUp>();

    //Constructor:
    public PickUp(GameObject thisobject, Image tempimg) : base(thisobject)
    {
        this.Name = "PickUp" + ID.ToString();
        ThisObject.name = this.Name;
        AllItems.Add(this.Name, this);
        SetImage(tempimg);
    }

    //Public:
    public Image GetIcon()
    {
        return this.Icon;
    } 

    public void SetImage(Image temp)
    {
        this.Icon = temp;
    }
    //Private:
    private Image Icon;

}

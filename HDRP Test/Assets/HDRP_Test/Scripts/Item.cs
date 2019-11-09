﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Image ItemImage;
    public PickUp ThisItem;
    // Start is called before the first frame update
    void Start()
    {
        ThisItem = new PickUp(gameObject, ItemImage);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<mouseHovor>().mouseOver == true && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log(ThisItem.GetPosition());
            Player.AllPlayers[0].AddItemToInventory(ThisItem.GetName());
        }
    }
}

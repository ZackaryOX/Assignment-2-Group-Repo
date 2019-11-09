using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Character : MonoBehaviour
{
    Player Player1;
    public GameObject head;
    public Image defaultIcon;
    public Image selectedIcon;
    public Image emptyItem;
    Inventory hotbar;

    void Start()
    {
        hotbar = new Inventory(defaultIcon, selectedIcon, emptyItem);
        Player1 = new Player(gameObject, head, hotbar);
        
    }

    void Update()
    {
        hotbar.Update();
    }

    void LateUpdate()
    {
        Player1.Update();
    }

}
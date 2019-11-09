using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public static Dictionary<int, Player> AllPlayers = new Dictionary<int, Player>();
    static int Players = 0;
    //Constructor
    public Player(GameObject thisobject, GameObject temphead, Inventory tempinv) : base(thisobject)
    {
        Head = temphead;
        ThisInput = new PlayerInput(thisobject, temphead);
        ThisStamina = new Stamina(20, 2.5f, 10.0f);
        ThisInventory = tempinv;
        PlayerName = "Player" + Players.ToString();
        PlayerNumber = Players;
        Players++;
        AllPlayers.Add(PlayerNumber, this);

    }


    //Public
    public override void Update()
    {
        ThisInput.Update(ThisStamina);
    }

    public void AddItemToInventory(string pickupname) {
        this.ThisInventory.PickupItem(PickUp.AllItems[pickupname]);
    }
    public void UseItemInInventory(PickUp tempitem)
    {
        this.ThisInventory.UseItem(tempitem);
    }
    //Private
    private PlayerInput ThisInput;
    private Inventory ThisInventory;
    private GameObject Head;
    private string PlayerName;
    private int PlayerNumber;
    private Stamina ThisStamina;
}
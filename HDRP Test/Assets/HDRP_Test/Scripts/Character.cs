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
    public Image StaminaBar;
    public Image HealthBar;
    public Image SanityBar;
    Inventory hotbar;
    StatObserver Player1Stats;
    ScoreObserver Player1Score;

    void Start()
    {
        hotbar = new Inventory(defaultIcon, selectedIcon, emptyItem);
        Player1 = new Player(gameObject, head, hotbar);
        Player1Stats = new StatObserver(Player1);
        Player1Score = new ScoreObserver(Player1);
        Player1.SetState(new TeachWalkState());
    }

    void Update()
    {
        hotbar.Update();        
    }

    void LateUpdate()
    {
        Player1.Update();
        Vector3 Data = Player1Stats.GetData();
        StaminaBar.transform.localScale = new Vector3(Data.y/100, 1, 1);
        HealthBar.transform.localScale = new Vector3(Data.x/100, 1, 1);
        SanityBar.transform.localScale = new Vector3(Data.z/100, 1, 1);
    }

}
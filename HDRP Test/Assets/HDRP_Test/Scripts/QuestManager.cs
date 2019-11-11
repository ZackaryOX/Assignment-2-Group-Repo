using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    //Public
    public Image background;
    public Text text;
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject flashlightobj;
    private PickUp flashlight;

    private List<Quest> Quests = new List<Quest>() { };
    private List<Image> Images = new List<Image>() { };
    private List<Text> Texts = new List<Text>() { };


    private WaypointQuest q1;
    private PickUpQuest q2;
    private WaypointQuest q3;
    private PickUpQuest q4;
    private UseQuest q5;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = PickUp.AllItems[flashlightobj.name];

        q1 = new WaypointQuest("Reach waypoint", waypoint1);
        q2 = new PickUpQuest("Pick up flashlight", flashlight);
        q3 = new WaypointQuest("Reach waypoint", waypoint2);

        Quests.Add(q1);
        Quests.Add(q2);
        Quests.Add(q3);
        Quests[0].Activate();

        //Create UI
        for (int i = 0; i < Quests.Count; i++)
        {
            Images.Add(Instantiate(background, background.transform.parent));
            Images[i].transform.localPosition = new Vector3(660, 485 - 75 * i, 0);

            Texts.Add(Instantiate(text, text.transform.parent));
            Texts[i].transform.localPosition = new Vector3(660, 485 - 75 * i, 0);
            Texts[i].text = Quests[i].getName();
        }
        Images[0].color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        //Remove quest if completed
        if (Quests[0].getCompletion() == true)
        {
            Quests.RemoveAt(0);
            Images[0].transform.localPosition = new Vector3(-1000, -1000, 0);
            Images.RemoveAt(0);
            Texts[0].transform.localPosition = new Vector3(-1000, -1000, 0);
            Texts.RemoveAt(0);

            for (int i = 0; i < Images.Count; i++)
            {
                Images[i].transform.localPosition += new Vector3(0, 75, 0);
                Texts[i].transform.localPosition += new Vector3(0, 75, 0);
            }

            if (Quests.Count == 0)
                this.gameObject.SetActive(false);
            else
                Quests[0].Activate();

            if (Images.Count != 0)
                Images[0].color = Color.white;
        }

        if (Quests.Count != 0)
        {
            //Check only top quest
            Quests[0].Update();
        }
    }
}

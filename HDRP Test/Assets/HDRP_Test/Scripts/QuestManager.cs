using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest q1,q2,q3;
    private List<Quest> Quests = new List<Quest>() { };
    public Image background;
    public Text text;
    private List<Image> Images = new List<Image>() { };
    private List<Text> Texts = new List<Text>() { };

    // Start is called before the first frame update
    void Start()
    {
        q1 = new Quest("Reach waypoint");
        q2 = new Quest("Pickup flashlight");
        q3 = new Quest("Use flashlight");

        Quests.Add(q1);
        Quests.Add(q2);
        Quests.Add(q3);

        for (int i = 0; i < Quests.Count; i++)
        {
            Images.Add(Instantiate(background, background.transform.parent));
            Images[i].transform.localPosition = new Vector3(660, 485 - 75 * i, 0);

            Texts.Add(Instantiate(text, text.transform.parent));
            Texts[i].transform.localPosition = new Vector3(660, 485 - 75 * i, 0);
            Texts[i].text = Quests[i].questName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Quests[0].isCompleted == true)
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
        }
        Images[0].color = Color.white;
    }
}

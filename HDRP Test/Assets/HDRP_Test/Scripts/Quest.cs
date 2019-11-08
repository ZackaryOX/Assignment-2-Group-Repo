using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string questName;
    public bool isCompleted = false;

    public Quest(string name)
    {
        questName = name;
    }

    public void Complete()
    {
        isCompleted = true;
    }
}

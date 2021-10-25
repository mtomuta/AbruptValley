using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Dictionary<string, Dialogue> dialogueDic = new Dictionary<string, Dialogue>();

    void Awake()
    {
        instance = this;
        Initiallize();
    }

    public void Initiallize()
    {
        Dialogue[] dialogues = XmlSerialization.Deserialize<Dialogue[]>("dialogues.xml");
        foreach (Dialogue dialogue in dialogues)
        {
            dialogueDic[dialogue.id] = dialogue;
        }
    }
}

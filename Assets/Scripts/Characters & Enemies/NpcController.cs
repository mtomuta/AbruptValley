using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : Interactable
{
    public string dialogueId;

    public void Interact()
    {
        DialogueBox.instance.startDialogue(DialogueManager.instance.dialogueDic[dialogueId]);
    }
}

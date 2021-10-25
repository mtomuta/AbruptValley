using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantController : Interactable
{
    public string dialogueId;

    public void Interact()
    {
        DialogueBox.instance.startDialogue(DialogueManager.instance.dialogueDic[dialogueId]);
    }
}

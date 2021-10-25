using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public static DialogueBox instance;
    public UnityEvent onStartDialogue;
    public UnityEvent onFinishDialogue;
    public TextMeshProUGUI textmesh;
    private Dialogue currentDialogue;
    private int lineIndex;

    private void Awake()
    {
        instance = this;
    }

    public void startDialogue(Dialogue dialogue)
    {
        onStartDialogue?.Invoke();
        currentDialogue = dialogue;
        lineIndex = 0;
        textmesh.text = currentDialogue.lines[lineIndex];
    }

    public void nextLine()
    {
        lineIndex++;
        if (currentDialogue.lines.Length <= lineIndex)
        {
            onFinishDialogue?.Invoke();
            return;
        }
        textmesh.text = currentDialogue.lines[lineIndex];
    }
}

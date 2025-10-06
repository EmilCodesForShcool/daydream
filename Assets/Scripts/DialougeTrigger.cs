using UnityEngine;
using System.Collections.Generic;

[System.Serializable] //Initialize dialouge with lines
public class DialogueLine
{
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue //Store the character dialouge that is written inspector
{
    public List<DialogueLine> dialougeLines = new List<DialogueLine>();
}
public class DialougeTrigger : MonoBehaviour
{
    public Dialogue dialogue; //Get the dialouge

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerDialogue();
        }
    }
}

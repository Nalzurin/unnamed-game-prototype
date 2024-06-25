using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogueManager : MonoBehaviour
{
    public TextAsset DialogueJSON;
    public string Id;
    public string Name;
    public Dictionary<string, string> Dialogues;
    void Start()
    {
        (string _Id, string _Name, Dictionary<string, string> _dialogues) = DialogueParser.ParseDialogue(DialogueJSON);
        Id = _Id; Name = _Name; Dialogues = _dialogues;
    }

    public string GetDialogue(string id)
    {
        if (id == null) return null;
        if (Dialogues.ContainsKey(id))
        {
            return Dialogues[id];
        }
        else
        {
            Debug.LogError("Dialogue with this ID doesn't exist!");
            return null;
        }
       
    }


}

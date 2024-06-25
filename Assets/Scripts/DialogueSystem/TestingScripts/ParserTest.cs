using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ParserTest : MonoBehaviour
{
    public GameObject character;
    void Start()
    {
        CharacterDialogueManager dialogueManager = character.GetComponent<CharacterDialogueManager>();
        if (dialogueManager != null)
        {
            // Test fetching some dialogues
            TestDialogueFetching(dialogueManager);
        }
        else
        {
            Debug.LogError($"Character {character.name} does not have a CharacterDialogueManager component.");
        }
    }
    void TestDialogueFetching(CharacterDialogueManager dialogueManager)
    {
        Debug.Log($"Testing dialogues for character: {dialogueManager.Name} (ID: {dialogueManager.Id})");

        // Define some test dialogue IDs
        string[] testIds = { "dialogue_intro", "generic_timeline", "evidence_wine_glass_owner", "invalid_id" };

        foreach (string id in testIds)
        {
            string dialogue = dialogueManager.GetDialogue(id);
            if (dialogue != null)
            {
                Debug.Log($"Dialogue [{id}]: {dialogue}");
            }
            else
            {
                Debug.LogWarning($"Dialogue ID '{id}' not found for character: {dialogueManager.Name}");
            }
        }
    }

}

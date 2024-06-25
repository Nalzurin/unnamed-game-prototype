using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public static class DialogueParser
{
    static public (string id, string name, Dictionary<string, string> dialogues) ParseDialogue(TextAsset characterFileName)
    {

        JObject jsonObject = JObject.Parse(characterFileName.ToString());

        string id = jsonObject["id"].ToString();
        string name = jsonObject["name"].ToString();

        Dictionary<string, string> dialogues = jsonObject["dialogues"].ToObject<Dictionary<string, string>>();
        Debug.Log($"Parsed json, id = {id}, name = {name}, dialogue intro = {dialogues["dialogue_intro"]}");
        return (id, name, dialogues);


    }

}


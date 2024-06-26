using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public TMP_Text HoverNameText;
    public RectTransform HoverNameBackdrop;

    // Method to update the character name in the UI
    public void DisplayHoverText(string hoverText)
    {
        HoverNameText.text = hoverText;
        HoverNameBackdrop.sizeDelta = HoverNameText.rectTransform.sizeDelta;
    }

    // Method to hide the character name
    public void HideCharacterName()
    {
        HoverNameText.text = "";
        HoverNameBackdrop.sizeDelta = Vector2.zero;
    }
}

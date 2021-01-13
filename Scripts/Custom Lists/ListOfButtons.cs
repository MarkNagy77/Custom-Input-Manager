using UnityEngine;

[System.Serializable]
public class ListOfButtons
{
    public string label;
    public GameObject button;

    public ListOfButtons(string newLabel, GameObject newButton)
    {
        label = newLabel;
        button = newButton;
    }
}

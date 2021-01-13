using UnityEngine;

[System.Serializable]
public class ListOfControls
{
    public string keyMap;
    public KeyCode defaultKey;
    public float axisValue;
    public bool horizontal;

    public ListOfControls(string newKeyMap, KeyCode newKey)
    {
        keyMap = newKeyMap;
        defaultKey = newKey;
    }
}

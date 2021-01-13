using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameInputManager
{

    public static Dictionary<string, KeyCode> keys;
    public static Dictionary<string, KeyCode> alternativeKeys = new Dictionary<string, KeyCode>();

    public static List<string> keyMaps;
    public static List<string> alternativeKeyMaps = new List<string>();

    public static List<KeyCode> defaults;
    public static List<KeyCode> alternativeDefaults = new List<KeyCode>();

    public static void SetAlternative()
    {
        alternativeKeyMaps.Add(keyMaps[0]);
        alternativeKeyMaps.Add(keyMaps[1]);
        alternativeKeyMaps.Add(keyMaps[2]);
        alternativeKeyMaps.Add(keyMaps[3]);
        alternativeDefaults.Add(KeyCode.UpArrow);
        alternativeDefaults.Add(KeyCode.DownArrow);
        alternativeDefaults.Add(KeyCode.LeftArrow);
        alternativeDefaults.Add(KeyCode.RightArrow);

        for(int i = 0; i < alternativeKeyMaps.Count; ++i)
        {
            alternativeKeys.Add(alternativeKeyMaps[i], alternativeDefaults[i]);
        }
    }
    
    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if (!keys.ContainsKey(keyMap))
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);

        string badOne = "";
        foreach(string s in keys.Keys)
        {
            if (keys[s] == key)
            {
                badOne = s;
            }
        }
        keys[badOne] = KeyCode.None;

        keys[keyMap] = key;
        
        int i = 0;
        foreach(KeyCode k in keys.Values)
        {
            if(defaults.Count > i)
            {
                defaults[i] = k;
                i++;
            }
        }
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keys[keyMap]) || Input.GetKeyDown(alternativeKeys[keyMap]);
    }

    public static bool GetKey(string keyMap)
    {
        return Input.GetKey(keys[keyMap]) || Input.GetKey(alternativeKeys[keyMap]);
    }

    public static bool GetKeyUp(string keyMap)
    {
        return Input.GetKeyUp(keys[keyMap]) || Input.GetKeyUp(alternativeKeys[keyMap]);
    }
}

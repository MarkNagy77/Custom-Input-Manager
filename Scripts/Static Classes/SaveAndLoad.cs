using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public static void SaveNewKey(string name, string value)
    {
        PlayerPrefs.SetString(name, value);
    }

    public static string LoadKeys(string keyMap, string defaultValue)
    {
        return PlayerPrefs.GetString(keyMap, defaultValue);
    }

    public static void SaveValue(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
    }

    public static int LoadValue(string name, int defaultValue)
    {
        return PlayerPrefs.GetInt(name, defaultValue);
    }

    public static void SaveFloatValue(string name, float value)
    {
        PlayerPrefs.SetFloat(name, value);
    }

    public static float LoadFloatValue(string name, float value)
    {
        return PlayerPrefs.GetFloat(name, value);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputsInitialize : MonoBehaviour //needs to awake with the game
{
    public static CustomInputsInitialize Instance = null;

    public List<ListOfControls> defaultControlls = new List<ListOfControls>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetDefaultControlls();
        GameInputManager.SetAlternative();
        SetMusicNSounds();
        SetGrafics();
        SetResolution();
    }



    //Set controls
    private void SetDefaultControlls()
    {
        GameInputManager.keyMaps = new List<string>();
        GameInputManager.defaults = new List<KeyCode>();
        GameInputManager.keys = new Dictionary<string, KeyCode>();
        for (int i = 0; i < defaultControlls.Count; ++i)
        {
            GameInputManager.keyMaps.Add(defaultControlls[i].keyMap);
            GameInputManager.defaults.Add((KeyCode)Enum.Parse(typeof(KeyCode), SaveAndLoad.LoadKeys(GameInputManager.keyMaps[i], defaultControlls[i].defaultKey.ToString())));
            GameInputManager.keys.Add(GameInputManager.keyMaps[i], GameInputManager.defaults[i]);
        }
    }

    private void SetMusicNSounds()
    {
        //use this to get saved value for players
        SaveAndLoad.LoadFloatValue("music", 1);

        SaveAndLoad.LoadFloatValue("sound", 1);
        
    }

    private void SetGrafics()
    {
        QualitySettings.SetQualityLevel(SaveAndLoad.LoadValue("grafics", 1));
        QualitySettings.vSyncCount = SaveAndLoad.LoadValue("vsync", 1);
        QualitySettings.antiAliasing = SaveAndLoad.LoadValue("antialiasing", 1);

        if (SaveAndLoad.LoadValue("shadows", 1) == 1)
            QualitySettings.shadows = ShadowQuality.All;
        else
            QualitySettings.shadows = ShadowQuality.Disable;
    }

    private void SetResolution()
    {
        var val = SaveAndLoad.LoadValue("resolution", 1);
        Screen.SetResolution(Screen.resolutions[val].width, Screen.resolutions[val].height, Screen.fullScreen);
    }

}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour // needs to awake with settings screen
{
    private GameObject currentKey;
    
    public static SettingsManager Instance = null;
    public Slider music, sounds;
    public Dropdown graficDropdown, resolutionsDropdown;
    public Toggle vsync, shadows, antialiasing;
    public Color32 normal = new Color32(40, 176, 39, 255);
    public Color32 selected = new Color32(229, 45, 40, 255);
    public List<ListOfButtons> buttons = new List<ListOfButtons>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultControlls();
        SetResolutionsOptions();
        SetToggles();
    }

    //Set labels, buttons
    private void SetDefaultControlls()
    {
        music.value = SaveAndLoad.LoadFloatValue("music", 1);
        sounds.value = SaveAndLoad.LoadFloatValue("sound", 1);

        graficDropdown.value = SaveAndLoad.LoadValue("grafics", 1);

        for (int i =0; i<buttons.Count; ++i)
        {
            buttons[i].button.GetComponentInParent<Text>().text = buttons[i].label;
            buttons[i].button.GetComponentInChildren<Text>().text = GameInputManager.defaults[i].ToString();
            buttons[i].button.GetComponent<KeyMaps>().keyMap = CustomInputsInitialize.Instance.defaultControlls[i].keyMap;
        }
    }

    private void SetResolutionsOptions()
    {
        resolutionsDropdown.ClearOptions();

        for(int i = 0; i < Screen.resolutions.Length; ++i)
        {
            var newData = new Dropdown.OptionData();
            newData.text = Screen.resolutions[i].width + " x " + Screen.resolutions[i].height;
            resolutionsDropdown.options.Add(newData);
        }

        resolutionsDropdown.value = SaveAndLoad.LoadValue("resolution", 1);
    }

    private void SetToggles()
    {
        if (SaveAndLoad.LoadValue("vsync", 1) == 1)
            vsync.isOn = true;
        else
            vsync.isOn = false;

        if (SaveAndLoad.LoadValue("shadows", 1) == 1)
            shadows.isOn = true;
        else
            shadows.isOn = false;

        if (SaveAndLoad.LoadValue("antialiasing", 1) == 1)
            antialiasing.isOn = true;
        else
            antialiasing.isOn = false;
    }

    //Listenning for change key, change it and store it at playerprefs
    private void OnGUI()
{
    if (currentKey != null)
    {
        Event e = Event.current;
        if (e.isKey)
        {
            GameInputManager.SetKeyMap(currentKey.GetComponent<KeyMaps>().keyMap, e.keyCode);
            for(int i = 0; i < buttons.Count; ++i)
                {
                    buttons[i].button.GetComponentInChildren<Text>().text = GameInputManager.defaults[i].ToString();
                }
            currentKey.GetComponent<Image>().color = normal;
            SaveAndLoad.SaveNewKey(currentKey.GetComponent<KeyMaps>().keyMap, e.keyCode.ToString());
            currentKey = null;
        }
    }
}

public void ChangeKey(GameObject clicked)
{
    if (currentKey != null)
        currentKey.GetComponent<Image>().color = normal;

    currentKey = clicked;
    currentKey.GetComponent<Image>().color = selected;
}

    //Set grafics quality level
    public void ChangeGraficsLevel(int level)
    {
            QualitySettings.SetQualityLevel(level);
            SaveAndLoad.SaveValue("grafics", level);
    }

    public void ChangeMusic(float value)
    {
        SaveAndLoad.SaveFloatValue("music", value);
    }

    public void ChangeSounds(float value)
    {    
        SaveAndLoad.SaveFloatValue("sound", value);       
    }

    public void ChangeResolution(int val)
    {
        Screen.SetResolution(Screen.resolutions[val].width, Screen.resolutions[val].height, Screen.fullScreen);
        SaveAndLoad.SaveValue("resolution", val);
    }

    public void SetVSync(bool b)
    {
        if (b)
        {
            QualitySettings.vSyncCount = 1;
            SaveAndLoad.SaveValue("vsync", 1);
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            SaveAndLoad.SaveValue("vsync", 0);
        }
    }

    public void SetShadows(bool b)
    {
        if (b)
        {
            QualitySettings.shadows = ShadowQuality.All;
            SaveAndLoad.SaveValue("shadows", 1);
        }
        else
        {
            QualitySettings.shadows = ShadowQuality.Disable;
            SaveAndLoad.SaveValue("shadows", 0);
        }
    }

    public void SetAntialiasing(bool b)
    {
        if (b)
        {
            QualitySettings.antiAliasing = 1;
            SaveAndLoad.SaveValue("antialiasing", 1);
        }
        else
        {
            QualitySettings.antiAliasing = 0;
            SaveAndLoad.SaveValue("antialiasing", 0);
        }
    }
}

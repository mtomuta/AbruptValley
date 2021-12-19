using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            //resolutions[i].Equals(Screen.currentResolution)
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Behaviour()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            ActiveMainMenu();
        }
        else if (SceneManager.GetActiveScene().name == "Valley" || SceneManager.GetActiveScene().name == "Dungeon")
        {
            ActivePauseMenu();
        }
    }

    public void ActiveMainMenu()
    {
        mainMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void ActivePauseMenu()
    {
        mainMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetQuality (int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

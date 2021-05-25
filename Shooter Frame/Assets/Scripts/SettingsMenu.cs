using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown resDropdown;
    Resolution[] resuluciones;
    private void Start()
    {
        resuluciones = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResIndex = 0;
        for (int i = 0; i<resuluciones.Length; i++)
        {
            string option = resuluciones[i].width + "x" + resuluciones[i].height;
            options.Add(option);
            if (resuluciones[i].width == Screen.currentResolution.width && resuluciones[i].height == Screen.currentResolution.height) { currentResIndex = i; }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();

    }
    public void  SetQuality (int IndicadorCalidad)
    {
        QualitySettings.SetQualityLevel(IndicadorCalidad);
    }

    public void SetFullScreen (bool isfullScreen)
    {
        Screen.fullScreen = isfullScreen;
    }

    public void setResolution(int ResolutionIndex)
    {
        Resolution resolu = resuluciones[ResolutionIndex];
        Screen.SetResolution(resolu.width, resolu.height, Screen.fullScreen);
    }

    public void IrMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}

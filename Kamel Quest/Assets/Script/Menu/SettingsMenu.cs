using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
// Author : Elouan

///<summary>
/// The <class> SettingMenu </class> is used for the setting menu to allow to user to change some settings
///
///</summary>

public class SettingsMenu : MonoBehaviour
{
    // For audio settings
    public AudioMixer audioMixer;
    public Slider VolumeSlider;
    
    // For resolution settings
    public Dropdown dropDownResolution;
    private Resolution[] resolutions;


    ///<summary>
    /// <para>Start is called before the first frame update</para>
    /// <para> It set all allowed resolution on the ResolutionDropDown and set it to the current resolution (it convert reolutions array in a options list) </para>
    /// <returns>
    /// Return void
    /// </returns>
    /// </summary>
    private void Start()
    {

        resolutions = Screen.resolutions;
        VolumeSlider.value = PlayerPrefs.GetFloat("volume",0);
        SetVolume(PlayerPrefs.GetFloat("volume", 0));

        dropDownResolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        // Build the list of resolution
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        dropDownResolution.AddOptions(options);
        dropDownResolution.value = currentResolutionIndex;
        dropDownResolution.RefreshShownValue();
    }


    ///<summary>
    /// Set the Master mixer audio volume 
    ///<param Name="volume"> reduction on volume to apply, depend to the slider "VolumeSlider" of the canvas
    ///<returns>
    /// Return void
    ///</returns>
    ///</summary>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
        PlayerPrefs.SetFloat("volume",volume);
    }
    
    ///<summary>
    /// Set the game quality corresponding to the index in parameter
    ///<param Name="qualityIndex"> the index of the quality to set. Depend of DropDownQuality in canvas
    /// Return void
    ///</returns>
    /// Six quality are avaible : very low, low, mdeium, high, very high and ultra
    ///</summary>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    ///<summary>
    /// The game windows will take all the screen or not
    ///<param Name="isFullScreen"> Is a bool, which depend of the ToggleFullScreen
    /// Return void
    ///</returns>
    ///</summary>
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    ///<summary>
    /// Set the resolution to the one selected
    ///<param Name="resolutionIndex"> Index of resolution to set, depend to the selection of ResolutionDropDown
    /// List of resolution available is build in start function.
    ///<returns>
    /// Return void
    ///</returns>

    ///</summary>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}

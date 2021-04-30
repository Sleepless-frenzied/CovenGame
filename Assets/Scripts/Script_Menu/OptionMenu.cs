using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    public TMP_Text TextVolume;
    public TMP_Text TextSFX;

    public TMP_Dropdown Quality_Dropdown;
    
    public Toggle Toggle_Fullscreen;

    public Toggle Toggle_mute;

    public int FPS = -1;
    void Start()
    {
        //FPS MANAGER
        Application.targetFrameRate = FPS;
        
        //FULLSCREEN MANAGER
        Toggle_Fullscreen.isOn = Screen.fullScreen;
        
        //QUALITY MANAGER
        Quality_Dropdown.value = QualitySettings.GetQualityLevel();

        //TOGGLE MUTE
        
        //RESOLUTION MANAGER
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0; i <resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        
        
        // VOLUME MANAGER
        float tmp;
        float tmp2;
        audioMixer.GetFloat("MainVolume", out tmp);
        audioMixer.GetFloat("SFX", out tmp2);
        
        TextVolume.text = "Volume " + (int) (100+tmp);
        TextSFX.text = "SFX " + (int) (100+tmp2);
        //FPS MANAGER
        Application.targetFrameRate = -1;
    }

    //DROPDOWN RESOLUTION
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    } 
    
    //TOGGLE FULLSCREEN
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //DROPDOWN QUALITY
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    
    //SLIDER VOLUME MASTER
    public void SetVolumeMaster(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
        TextVolume.text = "Volume " + (int) (100+volume);
    }
    
    
    //SLIDER VOLUME SFX
    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
        TextSFX.text = "SFX " + (int) (100 + volume);
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void SetFPS(TMP_Dropdown drop)
    {
        switch (drop.value)
        {
            case 0 :
                Application.targetFrameRate = 30;
                break;
            case 1:
                Application.targetFrameRate = 60;
                break;
        }
    }
}

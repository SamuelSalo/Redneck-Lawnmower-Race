using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    #region Variables
    public AudioMixer audioMixer;
    #endregion
    #region Methods
    //Property methods for menu events
    public void SetEffectVolume (float vol) => audioMixer.SetFloat("Effects", vol);
    public void SetMusicVolume (float vol) => audioMixer.SetFloat("Music", vol);
    public void SetVSync (bool val) => QualitySettings.vSyncCount = val ? 1 : 0;
    public void SetQualityPreset (float val) => QualitySettings.SetQualityLevel((int)val, true);
    #endregion
}

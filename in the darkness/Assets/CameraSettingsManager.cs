using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraSettingsManager : MonoBehaviour
{
    private const float DefaultVolume = 100f;
    private const float DefaultExposure = 2.14f;

   public AudioListener audioListener;
    private PostProcessingBehaviour postProcessingBehaviour;
    private PostProcessingProfile profile;

    private void Start()
    {
        
        postProcessingBehaviour = GetComponent<PostProcessingBehaviour>();

        if (postProcessingBehaviour != null)
        {
            profile = postProcessingBehaviour.profile;
        }

        LoadSettings();
    }

    public void LoadSettings()
    {
        // Carica il volume dell'AudioListener
        
            float volume = PlayerPrefs.GetFloat("Volume", DefaultVolume)/100;
            AudioListener.volume = Mathf.Clamp01(volume);
            Debug.Log("Volume caricato da PlayerPrefs: " + volume);
            Debug.Log("Volume impostato su AudioListener: " + AudioListener.volume);
        

        // Carica l'esposizione
        if (profile != null)
        {
            var colorGrading = profile.colorGrading;
            if (colorGrading != null)
            {
                var settings = colorGrading.settings;
                settings.basic.postExposure = PlayerPrefs.GetFloat("Exposure", DefaultExposure);
                colorGrading.settings = settings;
            }
        }
    }
}

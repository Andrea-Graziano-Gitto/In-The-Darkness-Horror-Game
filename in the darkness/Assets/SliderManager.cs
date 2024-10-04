using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderManager : MonoBehaviour
{
    [Header("UI Components")]
    public Slider slider;
    public TMP_Text valueText;

    [Header("PlayerPrefs Settings")]
    public string playerPrefKey;
    public float defaultValue = 100f;

    [Header("Optional Settings Loader")]
    public MonoBehaviour settingsLoaderScript;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(playerPrefKey, defaultValue);
        UpdateSliderText(slider.value);
        slider.onValueChanged.AddListener(OnSliderValueChanged);

        Debug.Log("Inizializzato slider con valore: " + slider.value);
    }

    public void OnSliderValueChanged(float value)
    {
        UpdateSliderText(value);
        PlayerPrefs.SetFloat(playerPrefKey, value);
        Debug.Log("Valore " + playerPrefKey + " salvato nei PlayerPrefs: " + value);

        if (settingsLoaderScript != null)
        {
            var method = settingsLoaderScript.GetType().GetMethod("LoadSettings");
            if (method != null)
            {
                method.Invoke(settingsLoaderScript, null);
                Debug.Log("LoadSettings() chiamato per aggiornare le impostazioni.");
            }
            else
            {
                Debug.LogWarning("Il metodo LoadSettings() non è stato trovato nello script assegnato.");
            }
        }
    }

    private void UpdateSliderText(float value)
    {
        valueText.text = Mathf.RoundToInt(value).ToString();
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
}

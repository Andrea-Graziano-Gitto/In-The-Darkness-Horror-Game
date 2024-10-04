using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light light1;                 // Prima luce da gestire
    public float minIntensity1 = 0.5f;   // Intensità minima per la prima luce
    public float maxIntensity1 = 1.0f;   // Intensità massima per la prima luce

    public Light light2;                 // Seconda luce da gestire
    public float minIntensity2 = 0.2f;   // Intensità minima per la seconda luce
    public float maxIntensity2 = 0.8f;   // Intensità massima per la seconda luce

    public float flickerDuration = 2.0f; // Durata dell'effetto di flickering
    public float intervalMin = 3.0f;     // Intervallo minimo tra i flicker
    public float intervalMax = 7.0f;     // Intervallo massimo tra i flicker

    void Start()
    {
        // Avvia il flicker sincronizzato per entrambe le luci
        StartCoroutine(FlickerBothLights());
    }

    IEnumerator FlickerBothLights()
    {
        while (true)
        {
            float duration = Random.Range(flickerDuration / 2, flickerDuration);
            float waitTime = Random.Range(intervalMin, intervalMax);
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;

                // Interpola l'intensità di entrambe le luci
                float intensity1 = Mathf.Lerp(maxIntensity1, minIntensity1, Mathf.PingPong(t * 2, 1));
                float intensity2 = Mathf.Lerp(maxIntensity2, minIntensity2, Mathf.PingPong(t * 2, 1));

                light1.intensity = intensity1;
                light2.intensity = intensity2;

                yield return null;
            }

            // Mantieni entrambe le luci al loro massimo finché non inizia il prossimo flicker
            light1.intensity = maxIntensity1;
            light2.intensity = maxIntensity2;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
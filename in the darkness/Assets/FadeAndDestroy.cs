using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeAndDestroy : MonoBehaviour
{
    public RawImage rawImage; // Riferimento alla RawImage
    public float waitTime = 0.5f; // Tempo di attesa prima di iniziare il fade
    public float fadeDuration = 0.5f; // Durata dell'animazione di fade

    private void Start()
    {
        // Avvia la coroutine per gestire il fade e la distruzione
        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        // Attendi per il tempo specificato
        yield return new WaitForSeconds(waitTime);

        // Colore originale della RawImage
        Color originalColor = rawImage.color;

        // Timer per gestire la durata del fade
        float timer = 0f;

        // Animazione di fade
        while (timer <= fadeDuration)
        {
            // Interpolazione della trasparenza da 1 (100%) a 0 (0%)
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            rawImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Incrementa il timer
            timer += Time.deltaTime;

            // Aspetta il prossimo frame
            yield return null;
        }

        // Assicurati che l'alpha sia esattamente 0
        rawImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Distruggi il GameObject subito dopo il fade
        Destroy(gameObject);
    }
}

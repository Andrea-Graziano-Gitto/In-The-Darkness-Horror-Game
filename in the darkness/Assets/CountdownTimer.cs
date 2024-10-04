using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text countdownText; // Riferimento al TextMeshPro
    public float pulseScale = 1.2f; // Scala della pulsazione
    public float pulseDuration = 0.2f; // Durata della pulsazione
    public int startCountdown = 10; // Numero iniziale del conto alla rovescia
    public GameObject Canvas;
    public GameObject player;
    public GameObject finale;
    private FirstPersonController fpc; // Riferimento al FirstPersonController

    private int currentCount;

    private void Start()
    {
        if (player != null)
        {
            fpc = player.GetComponent<FirstPersonController>();
        }
        currentCount = startCountdown;
        countdownText.text = currentCount.ToString();
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (currentCount >= 0)
        {
            // Avvia l'animazione di pulsazione
            StartCoroutine(PulseAnimation());

            // Aspetta un secondo
            yield return new WaitForSeconds(1f);

            // Aggiorna il conteggio
            currentCount--;

            // Aggiorna il testo del countdown
            if (currentCount >= 0)
            {
                countdownText.text = currentCount.ToString();
            }
        }

        // Distruggi l'oggetto quando il countdown arriva a 0
        fpc.ToggleCursorLock(); // Cambia lo stato del blocco del cursore
        
        Canvas.SetActive(true);
        finale.SetActive(true);
        player.SetActive(false);
        Destroy(gameObject);

    }

    private IEnumerator PulseAnimation()
    {
        Vector3 originalScale = countdownText.transform.localScale;
        Vector3 targetScale = originalScale * pulseScale;

        // Scala verso l'esterno
        float timer = 0f;
        while (timer <= pulseDuration)
        {
            countdownText.transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / pulseDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Ripristina la scala originale
        timer = 0f;
        while (timer <= pulseDuration)
        {
            countdownText.transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / pulseDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        countdownText.transform.localScale = originalScale;
    }
}

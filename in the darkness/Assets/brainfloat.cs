using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainFloat : MonoBehaviour
{
    public float minMoveAmplitude = 0.3f;        // Ampiezza minima del movimento su/giù
    public float maxMoveAmplitude = 0.7f;        // Ampiezza massima del movimento su/giù
    public float moveSpeed = 1.0f;               // Velocità del movimento su/giù
    public float rotationSpeed = 1.0f;           // Velocità di rotazione
    public int maxRotations = 6;                 // Numero massimo di rotazioni casuali prima di tornare alla rotazione originale

    private Vector3 originalPosition;            // Posizione originale del GameObject rispetto al genitore
    private Quaternion originalRotation;         // Rotazione originale del GameObject rispetto al genitore
    private int rotationCount = 0;               // Contatore di rotazioni
    private bool movingUp = true;                // Controlla se l'oggetto sta salendo o scendendo
    private Transform parentTransform;           // Trasform del genitore

    void Start()
    {
        // Salva la posizione e la rotazione originali del GameObject rispetto al genitore
        parentTransform = transform.parent;
        originalPosition = transform.localPosition; // Usa la posizione locale rispetto al genitore
        originalRotation = transform.localRotation; // Usa la rotazione locale rispetto al genitore

        // Avvia il movimento su/giù e la rotazione casuale
        StartCoroutine(FloatMovement());
        StartCoroutine(RandomRotation());
    }

    IEnumerator FloatMovement()
    {
        while (true)
        {
            float moveAmplitude = Random.Range(minMoveAmplitude, maxMoveAmplitude);

            // Movimento verso l'alto o verso il basso
            yield return StartCoroutine(MoveUpAndDown(moveAmplitude));
        }
    }

    IEnumerator MoveUpAndDown(float moveAmplitude)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.localPosition; // Usa la posizione locale rispetto al genitore
        Vector3 endPosition = originalPosition + new Vector3(0, movingUp ? moveAmplitude : -moveAmplitude, 0);

        while (elapsedTime < moveSpeed)
        {
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0f, 1f, elapsedTime / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = endPosition;
        movingUp = !movingUp; // Cambia direzione
    }

    IEnumerator RandomRotation()
    {
        while (true)
        {
            // Rotazione casuale
            yield return StartCoroutine(RotateRandomly());

            rotationCount++;
            // Controlla se abbiamo raggiunto il numero massimo di rotazioni
            if (rotationCount >= maxRotations)
            {
                // Torna alla rotazione originale
                yield return StartCoroutine(RotateToRotation(originalRotation));
                rotationCount = 0; // Reset del contatore di rotazioni
            }
        }
    }

    IEnumerator RotateRandomly()
    {
        // Genera un asse di rotazione casuale
        Vector3 randomAxis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // Genera un angolo di rotazione casuale tra 25 e 35 gradi, positivo o negativo
        float randomAngle = Random.Range(10f, 20f) * (Random.value > 0.5f ? 1 : -1);

        // Calcola la rotazione finale
        Quaternion targetRotation = Quaternion.AngleAxis(randomAngle, randomAxis) * transform.localRotation;

        // Ruota gradualmente verso la rotazione casuale
        yield return StartCoroutine(RotateToRotation(targetRotation));
    }

    IEnumerator RotateToRotation(Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        Quaternion startingRotation = transform.localRotation;

        while (elapsedTime < rotationSpeed)
        {
            transform.localRotation = Quaternion.Slerp(startingRotation, targetRotation, Mathf.SmoothStep(0f, 1f, elapsedTime / rotationSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = targetRotation;
    }
}
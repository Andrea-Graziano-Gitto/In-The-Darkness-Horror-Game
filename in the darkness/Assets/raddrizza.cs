using System.Collections;
using UnityEngine;

public class raddrizza : MonoBehaviour
{
    // Riferimento allo script che contiene la variabile lifted.
    public LiftableObject liftControl;

    // Angoli di rotazione target e velocità di rotazione.
    public Vector3 targetRotation = new Vector3(0, 90, 0);
    public float rotationSpeed = 1.0f;

    // Flag per controllare l'animazione.
    private bool isRotating = false;

    // Update è chiamato ad ogni frame.
    void Update()
    {
        // Controlla se il tasto "R" è premuto, se non è già in rotazione e se lifted è true.
        if (Input.GetKeyDown(KeyCode.R) && !isRotating && liftControl != null && liftControl.lifted)
        {
            StartCoroutine(RotateToTarget());
        }
    }

    // Coroutine per gestire l'animazione della rotazione.
    IEnumerator RotateToTarget()
    {
        isRotating = true;

        // Salva la rotazione iniziale e la rotazione target.
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(targetRotation);

        // Calcola il tempo totale per l'animazione.
        float elapsedTime = 0;

        // Ruota l'oggetto fino a raggiungere la rotazione target.
        while (elapsedTime < rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Assicurati che l'oggetto raggiunga esattamente la rotazione target.
        transform.rotation = endRotation;
        isRotating = false;
    }
}

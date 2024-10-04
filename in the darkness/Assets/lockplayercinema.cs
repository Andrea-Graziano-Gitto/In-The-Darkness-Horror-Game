using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerCinema : MonoBehaviour
{
    public float tempo;                  // Durata della pausa
    public GameObject player;            // Riferimento al player
    public Transform target;             // L'oggetto da guardare
    public float rotationSpeed = 1.0f;   // Velocità di rotazione
    public bool isRotating = false;      // Controlla se l'oggetto sta ruotando
    public Transform cameraTransform;   // Trasform della camera
    public bool fermo;
    void Awake()
    {
     

        if (cameraTransform == null)
        {
            Debug.LogError("Camera non trovata nella gerarchia player/joint/camera.");
            return;
        }

        fermo = true;
        // Disabilita il movimento del player
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        fpc.enabled = false;

        // Avvia la rotazione della camera
        isRotating = true;

        // Dopo un certo tempo, riprendi il controllo del player
        Invoke("Riprendi", tempo);
    }

    void Update()
    {
        if (fermo)
        {
            FirstPersonController fpc = player.GetComponent<FirstPersonController>();
            if (fpc.enabled) fpc.enabled = false;
        }
        if (isRotating && target != null && cameraTransform != null)
        {
            // Calcola la direzione verso il target
            Vector3 direction = target.position - cameraTransform.position;
            direction.y = 0;  // Mantieni l'asse Y invariato se vuoi solo una rotazione orizzontale

            // Calcola la rotazione desiderata verso il target
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Interpola la rotazione attuale verso quella desiderata
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Controlla se la rotazione è quasi completa
            if (Quaternion.Angle(cameraTransform.rotation, targetRotation) < 0.1f)
            {
                // Imposta la rotazione finale e ferma il movimento
                cameraTransform.rotation = targetRotation;
                isRotating = false; // Disabilita la rotazione
            }
        }
    }

    public void Riprendi()
    {
        // Riabilita il movimento del player
        fermo = false;
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        fpc.enabled = true;
    }
}

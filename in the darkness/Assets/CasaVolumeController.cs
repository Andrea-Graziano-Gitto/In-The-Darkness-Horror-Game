using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasaVolumeController : MonoBehaviour
{
    public AudioSource playerAudioSource; // Riferimento all'AudioSource del player
    public GameObject dentroCasa;         // Riferimento al GameObject dentroCasa
    public float volumeDentroCasa = 0.2f; // Volume quando dentroCasa è dentro il collider
    public float volumeFuoriCasa = 0.436f;// Volume quando dentroCasa è fuori dal collider
    public AudioSource audioSuolo; // Audio per quando il player si muove su qualsiasi superficie tranne il legno
    public AudioSource audioLegno; // Audio per quando il player si muove sul legno
    public GameObject dentrolegno;  // Riferimento al GameObject dentroCasa, usato per controllare il volume quando entra/esce dal collider

    private bool isMoving = false; // Stato di movimento del player
    private bool insideLegnoCollider = false; // Stato del player all'interno del collider di legno

    void Update()
    {
        // Controlla se il player sta premendo i tasti WASD
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
                   Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        // Gestisci l'audio in base al movimento e alla posizione del player
        if (isMoving)
        {
            if (insideLegnoCollider)
            {
                if (!audioLegno.isPlaying)
                {
                    audioLegno.time = Random.Range(0f, audioLegno.clip.length); // Imposta un punto di partenza casuale
                    audioLegno.Play();
                    audioSuolo.Stop();
                }
            }
            else
            {
                if (!audioSuolo.isPlaying)
                {
                    audioSuolo.time = Random.Range(0f, audioSuolo.clip.length); // Imposta un punto di partenza casuale
                    audioSuolo.Play();
                    audioLegno.Stop();
                }
            }
        }
        else
        {
            audioSuolo.Stop();
            audioLegno.Stop();
        }
    }
    // Metodo chiamato quando un oggetto entra nel collider della casa
    private void OnTriggerStay(Collider other)
    {
        // Controlla se l'oggetto che è entrato è dentroCasa
        if (other.gameObject == dentroCasa)
        {
            playerAudioSource.volume = volumeDentroCasa;
        }
        if (other.gameObject == dentrolegno)
        {
            insideLegnoCollider = true;
        }
    }

    // Metodo chiamato quando un oggetto esce dal collider della casa
    private void OnTriggerExit(Collider other)
    {
        // Controlla se l'oggetto che è uscito è dentroCasa
        if (other.gameObject == dentroCasa)
        {
            playerAudioSource.volume = volumeFuoriCasa;
        }
        if (other.gameObject == dentrolegno)
        {
            insideLegnoCollider = false;
        }
    }
}
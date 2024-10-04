using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finale : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject prefinale;
    public GameObject uscita;
    public GameObject pav;
    void Start()
    {
        StartCoroutine(CheckIfAudioFinished());
       uscita.SetActive(true);
        pav.SetActive(false);
    }

    IEnumerator CheckIfAudioFinished()
    {
        // Attende la durata della clip
        yield return new WaitForSeconds(audioSource.clip.length);

        // Esegui il codice desiderato qui dopo che l'audio è terminato
        prefinale.SetActive(true);
    }
}

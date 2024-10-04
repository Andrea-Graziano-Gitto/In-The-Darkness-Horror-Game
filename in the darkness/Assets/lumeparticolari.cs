using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lumeparticolari : MonoBehaviour, IInteractable
{
    public bool isPlayerInZone = false;
    private bool isActive;
    private bool isActivelight;
    public GameObject luce;
    public Material raggi;
    public Material telo;
    public GameObject particles;
    public GameObject Audioop;

    // Variabile per tracciare lo stato corrente dell'emissione
    private bool emissionEnabled;

    void Start()
    {
        // Imposta lo stato iniziale dell'emissione
        raggi.EnableKeyword("_EMISSION"); // Abilita l'emissione per i raggi
        telo.DisableKeyword("_EMISSION"); // Disabilita l'emissione per il telo
        emissionEnabled = true; // Imposta lo stato iniziale dell'emissione
    }

    void OnTriggerEnter(Collider other)
    {
        isActivelight = luce.activeSelf;
        isActive = particles.activeSelf;
        if (other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            isPlayerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            isPlayerInZone = false;
        }
    }

    public void Azione()
    {
        if (isPlayerInZone)
        {
            if (Audioop != null) Instantiate(Audioop, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            // Alterna lo stato dell'emissione
            emissionEnabled = !emissionEnabled;
            isActivelight = !isActivelight;
            luce.SetActive(isActivelight);

            if (emissionEnabled)
            {
                raggi.EnableKeyword("_EMISSION");
                telo.DisableKeyword("_EMISSION");
            }
            else
            {
                raggi.DisableKeyword("_EMISSION");
                telo.EnableKeyword("_EMISSION");
            }

            // Alterna lo stato attivo delle particelle
            isActive = !isActive;
            particles.SetActive(isActive);

            Debug.Log("cazzo");
        }
    }

    void Update()
    {
        // Aggiorna lo stato dell'emissione se necessario
    }
}

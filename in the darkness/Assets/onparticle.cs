using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onparticle : MonoBehaviour
{
    public ParticleSystem particleSystem; // Riferimento al ParticleSystem
    public float emissionCheckInterval = 0.1f; // Intervallo per controllare le emissioni

    private ParticleSystem.EmissionModule emissionModule;
    private int emissionThreshold;
    private int emissionCount;
    private int lastParticleCount;
    public GameObject Audioop;

    void Start()
    {
        if (particleSystem == null)
        {
            Debug.LogError("Particle System non assegnato.");
            return;
        }

        emissionModule = particleSystem.emission;
        lastParticleCount = particleSystem.particleCount;

        // Imposta un numero casuale di emissioni necessarie tra 8 e 12
        emissionThreshold = Random.Range(1, 3);
        emissionCount = 0;

        // Avvia il monitoraggio dell'emissione di particelle
        StartCoroutine(CheckParticleEmission());
    }

    IEnumerator CheckParticleEmission()
    {
        while (true)
        {
            yield return new WaitForSeconds(emissionCheckInterval);

            int currentParticleCount = particleSystem.particleCount;

            if (currentParticleCount > lastParticleCount)
            {
                // È stata emessa una nuova particella
                emissionCount++;

                if (emissionCount >= emissionThreshold)
                {
                    // Attiva l'azione desiderata
                    OnParticleEmitted();

                    // Resetta il contatore e imposta un nuovo threshold
                    emissionCount = 0;
                    emissionThreshold = Random.Range(1, 5);
                }
            }

            lastParticleCount = currentParticleCount;
        }
    }

    void OnParticleEmitted()
    {
        // Azione da eseguire quando il numero di emissioni raggiunge il threshold
        Debug.Log("Numero di emissioni raggiunto! Esegui azione.");
        if (Audioop != null) Instantiate(Audioop, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        // Aggiungi qui il tuo codice per attivare l'azione desiderata
    }
}
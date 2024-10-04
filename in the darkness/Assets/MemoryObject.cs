using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryObject : MonoBehaviour
{
    // Campo statico per mantenere la singola istanza del MemoryObject
    public static MemoryObject Instance { get; private set; }

    // Metodo Awake viene chiamato prima di Start
    void Awake()
    {
        // Se non esiste ancora un'istanza del MemoryObject, questa diventa l'istanza
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantieni questo oggetto anche tra i caricamenti di scene
        }
        // Se esiste già un'istanza, distruggi l'oggetto duplicato
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Esempio di dati che vuoi mantenere tra le scene
    public float volume;
    public float esposizione;
    public float sensitivity;
    public float fov;
    public bool secondtime; // In caso si vuole fare il load del game dopo aver fatto un finale

    // Altri metodi e logica per il tuo oggetto memoria
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVanish : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public GameObject torch; // Riferimento alla torcia
    public GameObject floor;
    private bool isHiddenByTorch = false; // Tiene traccia se il mesh renderer è nascosto dalla torcia
    int targetLayer;
    int ogLayer;

    // Start is called before the first frame update
    void Start()
    {
        targetLayer = LayerMask.NameToLayer("floor");
        ogLayer = LayerMask.NameToLayer("Default");
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogWarning("MeshRenderer non trovato sul GameObject.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (meshRenderer != null && other.gameObject.layer == LayerMask.NameToLayer("torch"))
        {
            
            torch = other.gameObject; // Salva il riferimento alla torcia
            meshRenderer.enabled = false;
            floor.layer = targetLayer;
            isHiddenByTorch = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (meshRenderer != null && other.gameObject.layer == LayerMask.NameToLayer("torch"))
        {
            torch = null; // Resetta il riferimento alla torcia
            meshRenderer.enabled = true;
            floor.layer = ogLayer;
            isHiddenByTorch = false;
        }
    }

    void Update()
    {
        // Controlla se la torcia è stata disattivata
        if (torch != null && !torch.activeSelf && isHiddenByTorch)
        {
            meshRenderer.enabled = true;
            floor.layer = ogLayer;
            isHiddenByTorch = false;

        }
    }
}

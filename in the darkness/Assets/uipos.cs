using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uipos : MonoBehaviour
{
    public RectTransform uiElement; // Riferimento al RectTransform dell'elemento UI
    public float xPosition = 100f;   // Nuova posizione X
    public float yPosition = 200f;   // Nuova posizione Y

    public void Awake()
    {
        if (uiElement == null)
        {
            Debug.LogError("RectTransform non assegnato!");
            return;
        }

        // Imposta la nuova posizione
        SetPosition(xPosition, yPosition);
        Invoke("lo", 0.1f);
    }

    public void lo()
    {
        SetPosition(xPosition, yPosition);
    }

        public void SetPosition(float x, float y)
    {
        if (uiElement == null)
        {
            Debug.LogError("RectTransform non assegnato!");
            return;
        }

        // Cambia la posizione in base ai valori passati
        uiElement.anchoredPosition = new Vector2(x, y);
    }
}
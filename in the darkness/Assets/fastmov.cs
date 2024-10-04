using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastmov : MonoBehaviour
{
    public float speed = 5.0f; // Velocit� di movimento in unit� per secondo
    public float tempoDistruzione = 5.0f;
    public void Awake()
    {
        Destroy(gameObject, tempoDistruzione);
    }
    void Update()
    {
        // Calcola il movimento sulla base della velocit� e del tempo trascorso
        float movement = speed * Time.deltaTime;

        // Sposta l'oggetto lungo l'asse X negativo
        transform.position -= new Vector3(movement, 0, 0);
    }
}
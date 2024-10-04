using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadroenigma : MonoBehaviour, IInteractable
{
    public GameObject leggio;
    public GameObject player;
    public GameObject camera;
    private bool delay;
    private bool isLeggioActive;
    public bool locked;
    public bool inposizione;
    public GameObject bottom;
    public GameObject quadro;
    public GameObject postEvent;
    public GameObject canPick;
    public GameObject Audiowin;
    public GameObject Audioread;
    public GameObject Audiored;
    public bool isPlayerInZone = false;

    void Start()
    {
        inposizione = false;
        locked = false;
        delay = false;
        isLeggioActive = false;
        leggio.SetActive(false);
    }

    public void Azione()
    {
        
        if (!locked && isPlayerInZone)
        {
            if (canPick == null || (canPick != null && canPick.activeSelf))
            {
                if (!isLeggioActive && !delay)
                {
                    ActivateLeggio();
                    if (Audioread != null) Instantiate(Audioread, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                }
            }
        }
    }

    public void post()
    {
        if (postEvent != null)
        {
            postEvent.SetActive(true);
            postEvent = null;
        }
    }

    private void ActivateLeggio()
    {
        leggio.SetActive(true);
        quadro.SetActive(false);

        delay = true;
        isLeggioActive = true;

        // Piccolo ritardo per evitare input multipli
        Invoke("ResetDelay", 0.2f);
    }

    private void DeactivateLeggio()
    {
        leggio.SetActive(false);
        quadro.SetActive(true);
        delay = true;
        isLeggioActive = false;
        //Invoke("post", 0.001f);
        if (Audiored != null) Instantiate(Audiored, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        // Piccolo ritardo per evitare input multipli
        Invoke("ResetDelay", 0.2f);
    }

    private void ResetDelay()
    {
        delay = false;
    }

    void OnTriggerStay(Collider other)
    {
       
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

    void Update()
    {
        if (isLeggioActive && Input.GetMouseButtonDown(0) && !delay)
        {
            DeactivateLeggio();
        }

        // Controllo la posizione del player e la rotazione della camera
        Vector3 playerPosition = player.transform.position;
        Vector3 targetPosition = new Vector3(-3.6f, 1.6f, 2.4f);
        float positionMargin = 0.5f;

        float cameraRotationX = camera.transform.rotation.eulerAngles.x;
        float cameraRotationMargin = 3.0f;

        if (Vector3.Distance(playerPosition, targetPosition) <= positionMargin &&
            Mathf.Abs(cameraRotationX) <= cameraRotationMargin)
        {
            inposizione = true;
        }

        if (isLeggioActive && !delay && inposizione && !locked)
        {
            locked = true;
            Debug.Log("inposizione");
            bottom.SetActive(true);
            if (Audiowin != null) Instantiate(Audiowin, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            DeactivateLeggio();
        }
    }
}

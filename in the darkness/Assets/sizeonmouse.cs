using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class sizeonmouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float scale = 1.6f;
    public Vector3 targetScale;
    public float animationSpeed = 5f;
    public int type;
    public GameObject scheda;
    public GameObject Audioclick;
    public GameObject Audiohover;

    private bool isHovered = false;

    // Riferimento allo script Language
    public Language languageScript;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("load"));
        targetScale = new Vector3(scale, scale, scale);
        originalScale = transform.localScale;
    }

    public void scene()
    {
        if (languageScript != null)
        {
            bool isEnglish = languageScript.IsEnglish();  // Ottieni lo stato della lingua
            if (isEnglish)
            {
                SceneManager.LoadScene("SkyboxTestENG");
            }
            else
            {
                SceneManager.LoadScene("SkyboxTest");
            }
        }
        else
        {
            Debug.LogWarning("LanguageScript non è assegnato! Caricamento della scena principale.");
            SceneManager.LoadScene("main menu");
        }
    }

    public void page()
    {
        scheda.SetActive(true);
    }

    public void lof()
    {
        if (languageScript != null)
        {
            bool isEnglish = languageScript.IsEnglish();  // Ottieni lo stato della lingua

            if (PlayerPrefs.GetInt("load") == 1)
            {
                if (isEnglish)
                {
                    SceneManager.LoadScene("loadtestENG");
                }
                else
                {
                    SceneManager.LoadScene("loadtest");
                }
            }
        }
        else
        {
            Debug.LogWarning("LanguageScript non è assegnato! Nessuna scena caricata.");
        }
    }

    public void Cliccato()
    {
        if (type == 0) Invoke("scene", 0.2f);
        if (type == 1) Invoke("page", 0.2f);
        if (type == 2) Invoke("lof", 0.2f);
        Instantiate(Audioclick, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }

    void Update()
    {
        if (isHovered)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, animationSpeed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, animationSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        Instantiate(Audiohover, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}

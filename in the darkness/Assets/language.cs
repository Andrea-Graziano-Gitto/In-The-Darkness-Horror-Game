using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public RawImage rawImage;
    public Texture italianTexture;
    public Texture englishTexture;
    public GameObject Audioclick;
    private bool isEnglish = false;

    public void OnButtonClick()
    {
        isEnglish = !isEnglish;
        Instantiate(Audioclick, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        if (isEnglish)
        {
            rawImage.texture = englishTexture;
        }
        else
        {
            rawImage.texture = italianTexture;
        }
    }

    public bool IsEnglish()
    {
        return isEnglish;
    }
}

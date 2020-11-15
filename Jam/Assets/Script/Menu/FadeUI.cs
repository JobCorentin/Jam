using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    public static FadeUI fade;

    public Image Fade;
    public Color transparent,Opaque;
    public float fadeInTime = 0.1f;
    public float fadeOutTime = 0.1f;


    private void Awake()
    {
        fade = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Fade = gameObject.GetComponent<Image>();
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        while (Fade.color.a > 0)
        {
            Fade.color = Color.Lerp(Fade.color, transparent, fadeOutTime * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator fadeIn()
    {
        while (Fade.color.a < 255)
        {
            Fade.color = Color.Lerp(Fade.color, Opaque, fadeInTime * Time.deltaTime);
            yield return null;
        }
    }
}

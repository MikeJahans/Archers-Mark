using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScene : MonoBehaviour
{
    public Image blackFade;

    // Start is called before the first frame update
    void Start()
    {
        blackFade.gameObject.SetActive(true);
        blackFade.canvasRenderer.SetAlpha(1.0f);
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        blackFade.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1.05f);
        blackFade.gameObject.SetActive(false);
    }

    public IEnumerator FadeOut()
    {
        blackFade.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(1.05f);

    }
}

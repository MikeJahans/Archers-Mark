using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioClip arrowDraw, arrowFire, hitDummy, score, scoreTwo;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // initializing audio clips
        arrowDraw = Resources.Load<AudioClip>("ArrowDraw");
        arrowFire = Resources.Load<AudioClip>("ArrowFire");
        hitDummy = Resources.Load<AudioClip>("HitDummy");
        score = Resources.Load<AudioClip>("Score");
        scoreTwo = Resources.Load<AudioClip>("Score1");

        // init audio source
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "arrowDraw":
                audioSource.PlayOneShot(arrowDraw);
                break;
            case "arrowFire":
                audioSource.PlayOneShot(arrowFire);
                break;
            case "hitDummy":
                audioSource.PlayOneShot(hitDummy);
                break;
            case "score":
                audioSource.PlayOneShot(score);
                break;
            case "scoreTwo":
                audioSource.PlayOneShot(scoreTwo);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    SpriteRenderer rend;
    public float speed = 4;
    public Rigidbody2D rb;
    private Vector2 screenBounds;

    public GameObject explosion;

    public ButtonController buttonController;


    private void Awake()
    {
        buttonController = FindObjectOfType<ButtonController>();
    }


    // Use this for initialization
    void Start()
    {
        // fade in
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
        speed = 0;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > screenBounds.y * 1.25)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if hit target, add point
        if (other.name == "Target")
        {
            //FindObjectOfType<ScoreController>().AddScore();
            ScoreController.instance.AddScore();
            Destroy(this.gameObject);

            // play sound
            AudioController.PlaySound("score");
        }
        // if hit dummy, reset game and display high score
        else if (other.name == "Dummy")
        {
            buttonController.RestartScreen();
            //FindObjectOfType<ButtonController>().RestartScreen();
            Debug.Log("Enemy hit, game over");


            // play sound
            AudioController.PlaySound("hitDummy");


            //GameObject e = Instantiate(explosion) as GameObject;
            //e.transform.position = transform.position;
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void Shoot()
    {
        speed = 4;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    IEnumerator FadeIn()
    {
        float fadeDurationInSeconds = 1f;
        float timeout = 0.05f;
        float fadeAmount = 1 / (fadeDurationInSeconds / timeout);

        for (float f = fadeAmount; f <= 1; f += fadeAmount)
        {
            rend = GetComponent<SpriteRenderer>();
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(timeout);
        }
    }
    public void StartArrowFadeIn()
    {
        StartCoroutine("FadeIn");
    }
}

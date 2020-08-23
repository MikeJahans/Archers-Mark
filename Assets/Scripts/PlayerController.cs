using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PLAYER VARIABLES


    // ARROW VARIABLES
    public GameObject arrowPrefab; // prefab of arrow to be fired
    public bool isDrawn = false; // bool to determine if arrow is drawn or not
    public Transform arrowSpawnPos; // position the arrow should spawn

    // ARROW COOLDOWN
    public float cooldownTime = .025f; // how long to cooldown
    float nextActionTime = 0f; // used to increment and count down the timer

    public float fireCooldownTime = 1.75f;
    float nextFireTime = 0f;

    public ButtonController buttonController;
    public ScoreController scoreController;



    private void Awake()
    {
        buttonController = FindObjectOfType<ButtonController>();
        scoreController = FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if tapped, draw an arrow
        if (Time.time > nextFireTime && !isDrawn && Input.GetKeyDown("space") || !isDrawn && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            DrawArrow();

            // timer to ensure the controls don't glitch due to being activated at the same time
            nextActionTime = Time.time + cooldownTime;
        }

        // if arrow is drawn, tap to fire
        if (isDrawn && Time.time > nextActionTime && Input.GetKeyDown("space") || isDrawn && Time.time > nextActionTime && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            FireArrow();

            // timer to ensure user waits before a new arrow is fired
            // nextActionTime = Time.time + cooldownTime;
            nextFireTime = Time.time + fireCooldownTime;
        }



        // DEBUGGING, REMOVE WHEN DONE
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("DEBUG | RESTART GAME SCREEN");
            buttonController.RestartScreen();
        }                   
        if(Input.GetKeyDown(KeyCode.D))
        {                   
            Debug.Log("DEBUG | CLEAR SCORE");
            scoreController.DeleteHighScore();
        }
    }

    public void DrawArrow()
    {
        // spawn arrow
        GameObject a = Instantiate(arrowPrefab);
        a.transform.position = arrowSpawnPos.transform.position;
        a.GetComponent<ButtonController>();

        // play sound
        AudioController.PlaySound("arrowDraw");

        // fade in arrow
        FindObjectOfType<ArrowController>().StartArrowFadeIn();

        // arrow drawn
        isDrawn = true;
        Debug.Log("Arrow Drawn");
    }

    public void FireArrow()
    {
        FindObjectOfType<ArrowController>().Shoot();
        isDrawn = false;

        // play sound
        AudioController.PlaySound("arrowFire");

        nextFireTime = Time.time + fireCooldownTime;
        Debug.Log("Arrow Fired, can draw");
    }

}
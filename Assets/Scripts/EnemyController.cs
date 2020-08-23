using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test turn collision");
        if (collision.gameObject.CompareTag("turn"))
        {
            if(movingLeft)
            {
                movingLeft = false;
            }
            else
            {
                movingLeft = true;
            }
        }
    }
}

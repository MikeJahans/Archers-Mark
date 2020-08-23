using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public float speed;

    void Start()
    {
    }

    void Update()
    {

        transform.Translate(-speed / 2, 0, 0);
    }
}

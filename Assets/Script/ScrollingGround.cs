using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingGround : MonoBehaviour
{
    public float velocity;
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (transform.position.x > -10)
            transform.position += new Vector3(-velocity * gm.globalSpeed * Time.deltaTime, 0, 0);
        else
            transform.position += new Vector3(20, 0, 0);
    }
}

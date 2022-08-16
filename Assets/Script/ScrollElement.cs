using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollElement : MonoBehaviour
{
    private GameManager gm;
    public float velocity = 5;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gm)
            transform.position += new Vector3(-gm.globalSpeed * velocity * Time.deltaTime, 0, 0);
    }
}

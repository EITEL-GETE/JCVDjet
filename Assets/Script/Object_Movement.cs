using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement : MonoBehaviour
{
    private GameManager gm;
    public float relativeSpeed = 1f;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.position += new Vector3(-relativeSpeed * gm.globalSpeed, 0, 0);
    }
}

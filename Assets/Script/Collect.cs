using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private GameManager GM;
    private int valCoin = 10;
    public AudioClip trashSound;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GM.GetComponent<GameManager>().addCoin(valCoin);
            AudioSource.PlayClipAtPoint(trashSound, transform.position);
            Destroy(gameObject);
        }
    }
}

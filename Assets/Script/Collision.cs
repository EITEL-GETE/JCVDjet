using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private GameObject Player;
    public AudioClip deathSound;

    private void Start()
    {
        Player = GameObject.Find("--- PLAYER ---");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.GetComponent<Death>().isDead = true;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(gameObject);
        }
        //Debug.Log("game over");   //ok
    }
}

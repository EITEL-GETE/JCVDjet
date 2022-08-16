using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private GameManager GM;
    public int bonus = 3;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GM.GetComponent<GameManager>().StartCoroutine("AddBonus");
            Destroy(gameObject);
        }
    }
}

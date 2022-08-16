using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletForce = 750f;
    public int sens = -1;

    private GameManager gm;
    public float velocity = 5;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gm)
            transform.position += new Vector3(sens * gm.globalSpeed * velocity * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            sens *= -1;
        //Debug.Log("collision1");   //ok

        if (collision.transform.tag == "Boss")
        {
            //Debug.Log("collision2");  //ok
            if (sens > 0)
            {
                collision.transform.GetComponent<Boss>().hp --;
                Destroy(gameObject);
            }
        }
    }
}

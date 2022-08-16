using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss")]
    public float bossSpeed = 2f;
    private int sens = 1;
    public int hp = 3;
    private Transform spawnPoint;

    [Header("Bullets")]
    public List<GameObject> bulletPrefabs;
    public float bulletSpawnRate;
    private float bulletTime, bulletTemp = 1f;

    private void Start()
    {
        spawnPoint = gameObject.transform.Find("BulletSpawn");
    }

    private void FixedUpdate()
    {
        RunTimers();

        if (bulletTime > bulletSpawnRate + bulletTemp)
        {
            bulletTemp = bulletTime;
            //Instantiate(bullet, spawnPoint.position - new Vector3(spawnDist,0,0), transform.rotation, transform);
            Instantiate(bulletPrefabs[Random.Range(0,bulletPrefabs.Count)], spawnPoint.position, transform.rotation, null);
        }

        if (hp <= 0)
        {
            GameObject.Find("-- SPAWNER --").GetComponent<Spawner>().isBossSpawn = false;
            Destroy(gameObject);
        }

        transform.position += new Vector3(0, sens * bossSpeed * Time.deltaTime, 0);
    }

    private void RunTimers()
    {
        bulletTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bord")
            sens *= -1;
    }
}

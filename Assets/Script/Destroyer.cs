using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < -30 || transform.position.x > 30)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    private GameManager gm;
    private Text text;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        text = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        text.text = "Score : ";
        text.text = text.text + " " + ((int)(gm.getScore())).ToString();
        // Debug.Log(text);
    }
}

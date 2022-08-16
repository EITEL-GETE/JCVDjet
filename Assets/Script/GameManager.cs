using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Level")]
    public float globalSpeed = 1f;
    public float speedIncrementor;

    [Header("Score")]
    public float score = 0;

    public float distance = 0;

    public int bonusMultiplier = 1;
    public int valBonus = 3;        //multiplier max
    public float bonusTime = 5;    //duree effet bonus

    public float coin = 0;          //cumule de coins
    public bool isPlaying = true;

    private void Update()
    {
        if (isPlaying)
        {
            distance += Time.fixedDeltaTime * bonusMultiplier;
            globalSpeed += Time.deltaTime * speedIncrementor;

            score = distance + coin;
        }
    }

    public void addCoin(int n)
    {
        coin += n;
    }

    IEnumerator AddBonus()
    {
        for (float ft = 0f; ft < bonusTime+0.1; ft += bonusTime)
        {
            if(ft<bonusTime)
                bonusMultiplier = valBonus;
            else
                bonusMultiplier = 1;

            yield return new WaitForSeconds(bonusTime);
        }
    }

    public float getScore()
    {
        return score;
    }
}

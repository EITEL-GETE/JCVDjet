using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public bool isDead = false;
    public bool isRevive = false; //est-ce qu"on a regardé une jolie pub pour continuer?
    private GameManager gm;
    public Canvas goCanvas;
    

    void Update()
    {
        if (isDead == true && isRevive == false)
        {
            //isRevive = Continue();

            if (isRevive == true) {
                isDead = false;
                //else <GameOver>
            } 
            else {
                gm = FindObjectOfType<GameManager>();
                gm.globalSpeed = 0;
                goCanvas.gameObject.SetActive(true);
            }
        }
        //else if (isDead == true && isRevive == true)
            //<GameOver>
    }

    public bool Continue()
    {
        //pauser le jeu
        //afficher options revive

        /*
        if(oui)
        {
            //pub
        
            return true;
        }
        else return false; 
         */

        //resume jeu

        return false;//temp
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);

    }
}

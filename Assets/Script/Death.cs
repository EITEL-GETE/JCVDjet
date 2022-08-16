using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public bool isDead;
    public bool isRevive; //est-ce qu"on a regardé une jolie pub pour continuer?
    public bool pause;
    public AudioSource SceneMusic;
    public AudioClip GameOverMusic;
    public AudioClip GameMusic;

    private GameManager gm;
    //private GameObject gameOverBkgd;
    //private GameObject continueScreen;

    public GameObject gameOverBkgd;
    public GameObject continueScreen;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        //gameOverBkgd = GameObject.Find("GameOverBackground");     //cha marche pas 
        //continueScreen = GameObject.Find("ContinueScreen");       //cha marche pas
        pause = false;
        isDead = false;
        isRevive = false;
    }

    void Update()
    {
        if (isDead)
        {
            changeMusic(GameOverMusic);
            if (!isRevive)
            {
                Continue();
            }
            else
                GameOver();                
        }
        else if(!pause)
        {
            continueScreen.SetActive(false);
            Play();
        }
    }

    private void Continue()
    {
        Pause();

        if (gameOverBkgd.activeSelf)    //on ne veut pas afficher ce choix si l'écran de gameover est activé
            continueScreen.SetActive(false);
        else
            continueScreen.SetActive(true);
    }

    public void OuiContinue()
    {
        //pub

        isDead = false;
        isRevive = true;
        changeMusic(GameMusic);
    }

    public void NonContinue()
    {
        //Debug.Log("gameover");    //ok

        GameObject.Find("--- PLAYER ---").GetComponent<Death>().GameOver();     //autrement ça ne marche pas :)
        Debug.Log("gameover");  //ok...
    }

    protected void GameOver()
    {
        Pause();

        gameOverBkgd.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gm.isPlaying = false;
    }

    public void Play()
    {
        Time.timeScale = 1;
        gm.isPlaying = true;
    }

    public void PauseBool()
    {
        pause = !pause;
    }

    public void changeMusic(AudioClip music)
    {
        SceneMusic.Stop();
        SceneMusic.clip = music;
        SceneMusic.Play();
        AudioListener.pause = false;

    }
}

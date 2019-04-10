using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class score : MonoBehaviour
{
    public AudioSource sound, music, boom;

    private int Score = 0;
    private int lives = 0;
    public Text tracker;
    public Text LifeTracker;
    private string scoreWords = "Baddies Killed: ";
    private string lifeWords = "Baddies Escaped: ";
    private GameObject pause = null;


    private int defaultHighScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        startgame();
        LifeTracker.text = lifeWords + lives;
        tracker.text = scoreWords + Score;
        pause = GameObject.Find("Panel");
        pause.SetActive(false);

        sound.volume = PlayerPrefs.GetFloat("SFXVol");
        boom.volume = PlayerPrefs.GetFloat("SFXVol");
        music.volume = PlayerPrefs.GetFloat("musicVol");

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!pause.activeInHierarchy)
            {
                PauseMe();
            }
            else
            {
                ContinueMe();
            }
        }
        if (pause.activeSelf)
        {

            sound.volume = PlayerPrefs.GetFloat("SFXVol");
            boom.volume = PlayerPrefs.GetFloat("SFXVol");
            music.volume = PlayerPrefs.GetFloat("musixVol");


            if (PlayerPrefs.GetFloat("musicMute") == 1)
            {
                music.Pause();
            }
            else
            {
                music.UnPause();
            }
            if (PlayerPrefs.GetFloat("SFXMute") == 1)
            {
                sound.Pause();
                boom.Pause();
            }
            else
            {
                sound.UnPause();
                boom.UnPause();
            }
        }

        if (lives + Score == 31 || !GameObject.Find("Ship"))
        {
            if (Score > PlayerPrefs.GetInt("high score 1"))
            {
              
                PlayerPrefs.SetInt("high score 5", PlayerPrefs.GetInt("high score 4"));
                PlayerPrefs.SetInt("high score 4", PlayerPrefs.GetInt("high score 3"));
                PlayerPrefs.SetInt("high score 3", PlayerPrefs.GetInt("high score 2"));
                PlayerPrefs.SetInt("high score 2", PlayerPrefs.GetInt("high score 1"));
                PlayerPrefs.SetInt("high score 1", Score);
            }
            else if (Score > PlayerPrefs.GetInt("high score 2"))
            {
                PlayerPrefs.SetInt("high score 10", PlayerPrefs.GetInt("high score 9"));
                PlayerPrefs.SetInt("high score 9", PlayerPrefs.GetInt("high score 8"));
                PlayerPrefs.SetInt("high score 8", PlayerPrefs.GetInt("high score 7"));
                PlayerPrefs.SetInt("high score 7", PlayerPrefs.GetInt("high score 6"));
                PlayerPrefs.SetInt("high score 6", PlayerPrefs.GetInt("high score 5"));
                PlayerPrefs.SetInt("high score 5", PlayerPrefs.GetInt("high score 4"));
                PlayerPrefs.SetInt("high score 4", PlayerPrefs.GetInt("high score 3"));
                PlayerPrefs.SetInt("high score 3", PlayerPrefs.GetInt("high score 2"));
                PlayerPrefs.SetInt("high score 2", Score);
            }
            else if (Score > PlayerPrefs.GetInt("high score 3"))
            {
                PlayerPrefs.SetInt("high score 5", PlayerPrefs.GetInt("high score 4"));
                PlayerPrefs.SetInt("high score 4", PlayerPrefs.GetInt("high score 3"));
                PlayerPrefs.SetInt("high score 3", Score);
            }
            else if (Score > PlayerPrefs.GetInt("high score 4"))
            {
                PlayerPrefs.SetInt("high score 5", PlayerPrefs.GetInt("high score 4"));
                PlayerPrefs.SetInt("high score 4", Score);
            }
            else if (Score > PlayerPrefs.GetInt("high score 5"))
            {
                PlayerPrefs.SetInt("high score 5", Score);
            }
   
            SceneManager.LoadScene("highscore");
        }

    }

    void counter()
    {
        Score += 1;
        tracker.text = scoreWords + Score;
    }

    void life()
    {
        lives += 1;
        LifeTracker.text = lifeWords + lives;

    }

    private void startgame()
    {
        if (!PlayerPrefs.HasKey("high score 1"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("high score 1", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("high score 2"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("high score 2", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("high score 3"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("high score 3", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("high score 4"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("high score 4", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("high score 5"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("high score 5", defaultHighScore); // If it’s not, then save one
        }
    
        if (!PlayerPrefs.HasKey("controller"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetInt("controller", 1); // If it’s not, then save one
        }

        if (!PlayerPrefs.HasKey("musicVol"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("musicVol", 1); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("SFXVol"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("SFXVol", 1); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("musicMute"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("musicMute", 1); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey("SFXMute"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("SFXMute", 1); // If it’s not, then save one
        }


    }
    private void PauseMe()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    private void ContinueMe()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

}
